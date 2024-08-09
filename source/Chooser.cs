using System.IO;
using System.Text;
using System;

namespace Chooser{
    
    public class Words
    {   
        private string choosenWord;
        
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
}