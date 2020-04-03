using System;
using System.Collections.Generic;

/*Створити об'єкт класу Текст, використовуючи класи Речення, Слово. 
 * Методи: доповнити текст, вивести на консоль текст, заголовок тексту.*/
namespace Laba_2_1_var1
{
    class Program
    {
        static void Main(string[] args)
        {
            Text text = new Text();
            text.AddText();
        }
    }
    class Text
    {
        public Sentense sentense;
        public Word word;
        public string heading;
        public List<string> sentenses;
        public Text()
        {
            sentense = new Sentense();
            word = new Word();
            sentenses = new List<string>();

        }
         public void Heading()
         {
             Console.WriteLine("Enter the heading: ");
             heading = Console.ReadLine();
         }
         
        public void AddText()
        {
            Console.WriteLine("Enter the heading: ");
            heading = Console.ReadLine();
            Sentense sent = new Sentense();
            while (sent.status)
            {
                if (Console.KeyAvailable == true)
                {
                    Console.Clear();
                    Console.WriteLine(heading);
                    var keyInfo = Console.ReadKey();
                    sent.AddSentense(sentenses, keyInfo);
                    for (int i = 0; i < sentenses.Count; i++)
                    {
                        Console.Write(sentenses[i] + " ");
                    }
                }
            }
        }
    }
    class Sentense
    {
        public bool status = true;
        public void AddSentense(List<string> sentense, ConsoleKeyInfo keyInfo)
        {
            Word word = new Word();
            sentense = new List<string>();
            if (keyInfo.Key == ConsoleKey.Spacebar)
            {
                sentense.Add(word.AddWord());
            }
            if (keyInfo.Key == ConsoleKey.Enter)
            {
                status = false;
            }
        }
    }
    class Word
    {
        public string AddWord()
        {
            string word = Console.ReadLine();
            return word;
        }
    }
}