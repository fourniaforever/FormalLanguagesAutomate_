using System;
using System.IO;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace FormalLanguagesAutomate_task2
{
    class Program
    {
        static public ListOfAllAutomates GetList()
        {

            List<Automate> result = new List<Automate>();

            Automate automateId = GetAutomate("ID.txt");
            result.Add(automateId);

            Automate automateInt = GetAutomate("INT.txt");
            result.Add(automateInt);

            Automate automateBool = GetAutomate("BOOL.txt");
            result.Add(automateBool);

            Automate automateOp = GetAutomate("OP.txt");
            result.Add(automateOp);

            Automate automateKw = GetAutomate("KW.txt");
            result.Add(automateKw);


            Automate automateSplit = GetAutomate("SPLIT.txt");
            result.Add(automateSplit);

            Automate automateRf = GetAutomate("RF.txt");
            result.Add(automateRf);
           
            return new ListOfAllAutomates(result);
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
            ListOfAllAutomates list = GetList();

            ///<summary>
            ///Консольный ввод
            ///</summary>

            Console.WriteLine("Input text to recognise:");
            string inf = Console.ReadLine();

            Console.WriteLine("Set the offset:");

            if (int.TryParse(Console.ReadLine(), out var offset) && offset >= 0)
            {
                var result = list.Move(inf, offset);

                foreach (var item in result)
                {
                    Console.WriteLine(item);

                }
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
