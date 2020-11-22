using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormalLanguagesAutomate_task1
{
    public class Automate
    { 
        public int Current { get; set; }
        public int Start { get; set; }
        public List<int> Finish { get; set; }

        Dictionary<KeyValuePair<int, string>, int> transitions;

        public KeyValuePair<KeyValuePair<int, string>, int>[] Transitions
        {
            get
            {
                return transitions.ToArray();
            }
            set
            {
                transitions = value.ToDictionary(x => x.Key, y => y.Value);
            }
        }

        public Automate()
        {
            transitions = new Dictionary<KeyValuePair<int, string>, int>();
        }
        public Automate(Dictionary<KeyValuePair<int, string>, int> transitions, int Start, List<int> Finish)
        {
            this.transitions = transitions;
            this.Start = Start;
            this.Finish = Finish;

        }


        public KeyValuePair<bool, int> Move(string inf, int offset)
        {
            Current = Start;
            bool IsItState = false;

            int Count = 0;
            int Index = offset;
            while (Index < inf.Length)
            {
                string s = inf[Index].ToString();
                if (transitions.ContainsKey(new KeyValuePair<int, string>(Current, s)))
                {
                    IsItState = true;
                    Count++;
                    Current = transitions[new KeyValuePair<int, string>(Current, s)];
                    Index++;
                }
                else
                {
                    break;
                }
            }
            if (!Finish.Contains(Current))
            {
                IsItState = false;
                Count = 0;
            }

            return new KeyValuePair<bool, int>(IsItState, Count);
        }


    }
}
