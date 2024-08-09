using System.Collections;
using System.Text;
using System.IO;
using System;
using Guess;
using Chooser;

namespace WordGuesser
{
    internal class WordGuesser
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
}