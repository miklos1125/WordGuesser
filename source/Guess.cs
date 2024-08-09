using System.Collections;
using System.Text;
using System;

namespace Guess{
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
                } else if (word.Contains(guess.ToString()))
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
            } while (showWord.ToString().Contains('_'.ToString()));
            Console.WriteLine(showWord.ToString());
            Console.WriteLine("\nSolution found in " + lettersUsed.Count + " rounds.");
            Console.WriteLine("\nPress a key to exit.");
            Console.ReadKey();
        }
    }
}