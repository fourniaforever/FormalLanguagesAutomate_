using System;
using System.IO;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace FormalLanguagesAutomate_task1
{
   public class Program
    {

        static public Lexem GetLexem()
        {
            Automate result = new Automate();
            var automation = GetAutomate("INT.txt");
            result = automation;
            return new Lexem(result);
        }
        static public Automate GetAutomate(string fileName)
        {

            Automate automate = new Automate();
            using (StreamReader streamReader = new StreamReader(fileName))
            {
                string s = streamReader.ReadToEnd();
                automate = JsonConvert.DeserializeObject<Automate>(s);
            }
            return automate;
        }

        static void Main(string[] args)
        {

            Lexem lexem = GetLexem();

            ///<summary>
            ///Консольный ввод
            ///</summary>

            Console.WriteLine("Input text to recognise:");
            string inf = Console.ReadLine();

            Console.WriteLine("Set the offset:");

            if (int.TryParse(Console.ReadLine(), out var offset) && offset >= 0)
            {
                var result = lexem.Move(inf, offset);

                Console.WriteLine(result);
            }
            else
            {
                Console.WriteLine("Incorrect offset");
            }

            ///<summary>
            ///Файловый ввод
            ///</summary>
            
            //using (StreamReader streamReader = new StreamReader("example.txt"))
            //{
            //    Console.WriteLine("Set the offset");
            //    int offset = int.Parse(Console.ReadLine());
                
            //    var result = automation.Move(streamReader.ReadToEnd(), offset);
            //    Console.WriteLine(result);
            //}

            Console.ReadKey();
        }
    }
}
