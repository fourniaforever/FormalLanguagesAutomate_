using System;
using System.IO;
using Newtonsoft.Json;

namespace FormalLanguagesAutomate_task1
{
    class Program
    {
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
                Automate automation = GetAutomate("INT.txt");

                Console.WriteLine("Input text to recognise:");
                string inf = Console.ReadLine();

                Console.WriteLine("Set the offset:");

                if (int.TryParse(Console.ReadLine(), out var offset) && offset >= 0)
                {
                    var result = automation.Move(inf, offset);

                    Console.WriteLine(result);
                }
                else
                {
                    Console.WriteLine("Incorrect offset");
                }

                Console.ReadKey();
        }
    }
}
