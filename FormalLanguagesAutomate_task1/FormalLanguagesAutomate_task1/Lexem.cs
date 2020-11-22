using System;
using System.Collections.Generic;
using System.Text;

namespace FormalLanguagesAutomate_task1
{
    public class Lexem
    {
        const string _class = "INT";

        Automate automate;
        Dictionary<string, Automate> lexems;

        public Lexem(Automate automate)
        {
            lexems = new Dictionary<string, Automate>();
            this.automate = automate;
            lexems.Add(_class,automate);
        }


        public KeyValuePair<string,string> Move(string inf,int offset)
        {
            var result = new KeyValuePair<string, string>();
            while (offset < inf.Length)
            {
                KeyValuePair<bool, int> resultAutomate;
                int Count = -1;
                
                string s = "";
                bool IsItCorrect = false;

                resultAutomate = automate.Move(inf, offset);
                if (resultAutomate.Value != 0)
                {
                   IsItCorrect = true;
                        if (resultAutomate.Value > Count)
                        {
                            Count = resultAutomate.Value;
                            s = inf.Substring(offset, resultAutomate.Value);
                        }
                        if (resultAutomate.Value == Count)
                        {
                           s = inf.Substring(offset, resultAutomate.Value);
                        }
                   }
                
                if (IsItCorrect)
                {
                    result = new KeyValuePair<string, string>(_class,s);
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
