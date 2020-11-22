using System;
using System.Collections.Generic;
using System.Text;

namespace FormalLanguagesAutomate_task2
{

    class ListOfAllAutomates
    {

        public string[] _class = new string[7] { "ID", "INT", "BOOL", "OP", "KW", "SPLIT", "RF" };
    
        List<Automate> automates;
       
        Dictionary< Automate,string> lexems;

        public ListOfAllAutomates(List<Automate> automates)
        {
            lexems = new Dictionary<Automate,string>();
            this.automates = automates ;
            for (int i = 0; i < automates.Capacity - 1; i++)
            {
               lexems.Add( automates[i],_class[i]);
            }
            
        }


        public List<KeyValuePair<string, string>> Move(string inf, int offset)
        {
            var result = new List<KeyValuePair<string, string>>();
            while (offset < inf.Length)
            {
                Automate automate = null;
                int Count = -1;

                string s = "";
                bool IsItCorrect = false;

                foreach(var item in automates)
                { 
                    var resultAutomate = item.Move(inf, offset);
                    if (resultAutomate.Value != 0)
                    {
                        IsItCorrect = true;
                        if (resultAutomate.Value > Count)
                        {
                            Count = resultAutomate.Value;
                            automate = item;
                            s = inf.Substring(offset, resultAutomate.Value);
                        }
                        if (resultAutomate.Value == Count)
                        {
                            if (item.Priority > automate.Priority)
                            {
                                automate = item;
                                s = inf.Substring(offset, resultAutomate.Value);
                            }
                        }
                    }
                }
                if (IsItCorrect)
                {
                    result.Add(new KeyValuePair<string, string>(lexems[automate],s));
                    offset += Count;
                }
                else
                {
                    offset++;
                }
            }
            return result;
        }
    }
}
