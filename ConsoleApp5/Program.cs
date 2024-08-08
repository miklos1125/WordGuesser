using System.Collections;
using System.Text;
using System.IO;

namespace WordGuesser
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("---> This is a word guesser game <---");
            Console.WriteLine("Choose a language!");
            Console.WriteLine("Type \"E\" for English, or \"H\" for Hungarian.");
            char key;
            Words w;
            
            do
            {
                key = Console.ReadKey().KeyChar;
                key = key.ToString().ToLower()[0];
            } while (key != 'e' && key != 'h');
            
            if (key == 'h')
            {
                w = new Words(Language.Hungarian);
            } else {
                w = new Words(Language.English);
            }
            string myWord = w.GetWord();
            w = null;
            Guessing guessing = new Guessing(myWord);
            guessing.Start();
        }
    }

    public enum Language {English, Hungarian}

    public class Words
    {
        private string choosenWord;
        
        /* OLD ARRAYS, NOW WE USE FILES 
        private string[] hunWords = {
            "csokifagyi", "macskaszőr", "cseresznyefa",
            "zivatar", "sétahajó", "délután", 
            "kalandfilm", "mesekönyv", "cápauszony", "víziszony"};
        
        private string[] engWords = {
            "claustrophobia", "mountain", "rainforest",
            "tornado", "midnight", "hippopotamus",
            "storyteller", "newspaper", "fisherman", "fireworks"};
        */
        public Words(Language lan)
        { 
            System.Random random = new System.Random();
            Encoding encoding = Encoding.UTF8;
            string[] content; 
            switch (lan)
            {
                case Language.English:
                    content = File.ReadAllLines("engwords.txt", encoding);
                    break;
                case Language.Hungarian:
                    content = File.ReadAllLines("hunwords.txt", encoding);
                    break;
                default:
                    content = File.ReadAllLines("engwords.txt", encoding);
                    break;
            }
            choosenWord = content[random.Next(0, content.Length)];
        }

        public string GetWord() { 
            return choosenWord;
        }
    }

    public class Guessing
    {
        private string word;
        private StringBuilder showWord;
        private ArrayList lettersUsed;

        public Guessing(string word)
        { 
            this.word = word;
            showWord = new StringBuilder();
            lettersUsed = new ArrayList();
            for (int i = 0; i < word.Length; i++)
            {
                showWord.Append("_");
            }
        }

        public void Start()
        {
            Console.Clear();
            Console.WriteLine("My word has " + word.Length + " letters.\n");
            do
            {
                Console.WriteLine(showWord.ToString());
                Console.WriteLine("\nGuess a letter!");
                char guess = Console.ReadKey().KeyChar;
                if (lettersUsed.Contains(guess))
                {
                    Console.WriteLine("\nAlready guessed: \"" + guess + "\"");
                } else if (word.Contains(guess))
                {
                    ArrayList indexList = new ArrayList();
                    for(int i = 0; i<word.Length;i++)
                    {
                        if (word[i] == guess) 
                        { 
                            indexList.Add(i);
                        }
                    }
                    lettersUsed.Add(guess);
                    foreach (int x in indexList)
                    {
                        showWord[x] = guess.ToString().ToLower()[0];
                    }
                    Console.WriteLine("\n");
                } else 
                {
                    Console.WriteLine("\n\"" + guess + "\" has no match!");
                    lettersUsed.Add(guess);
                }
            } while (showWord.ToString().Contains('_'));
            Console.WriteLine(showWord.ToString());
            Console.WriteLine("\nSolution found in " + lettersUsed.Count + " rounds.");
            Console.WriteLine("\nPress a key to exit.");
            Console.ReadKey();
        }
    }
}
