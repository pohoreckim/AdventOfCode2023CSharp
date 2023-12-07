using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_7
{
    internal readonly record struct Hand(string Cards, int Value)
    {
        public int Type
        {
            get
            {
                var counts = Cards.ToCharArray().GroupBy(x => x).Select(x => x.Count()).OrderByDescending(x => x).ToList();
                switch (counts.Count()) 
                {
                    case 5: return 0;
                    case 4: return 1;
                    case 3:
                        if (counts[0] == 3) return 3;
                        else return 2;
                    case 2: 
                        if (counts[0] == 3) return 4;
                        else return 5;
                    case 1: return 6;
                    default: return 0;
                }
            }
        }
        public static Dictionary<char, int> Mapping = new Dictionary<char, int>()
        {
            { '2', 0 },
            { '3', 1 },
            { '4', 2 },
            { '5', 3 },
            { '6', 4 },
            { '7', 5 },
            { '8', 6 },
            { '9', 7 },
            { 'T', 8 },
            { 'J', 9 },
            { 'Q', 10 },
            { 'K', 11 },
            { 'A', 12 }
        };
        public static int CompareHands(Hand hand1, Hand hand2)
        {
            if(hand1.Type > hand2.Type) return 1;
            else if(hand1.Type < hand2.Type) return -1;
            else
            {
                int i = 0;
                while(i < hand1.Cards.Length)
                {
                    if (Mapping[hand1.Cards.ToCharArray()[i]] > Mapping[hand2.Cards.ToCharArray()[i]]) return 1;
                    else if (Mapping[hand1.Cards.ToCharArray()[i]] < Mapping[hand2.Cards.ToCharArray()[i]]) return -1;
                    i++;
                }
                return 0;
            }
        }
    }
}
