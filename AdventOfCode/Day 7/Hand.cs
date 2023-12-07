using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_7
{
    internal readonly record struct Hand(string Cards, int Value)
    {
        public int Type(bool jokers = false) 
        {
            return jokers && Cards.Contains('J') ? TypeWithJokers(this.Cards) : TypeWithoutJokers(this.Cards);            
        }
        private int TypeWithoutJokers(string cards)
        {
            var counts = cards.ToCharArray().GroupBy(x => x).Select(x => x.Count()).OrderByDescending(x => x).ToList();
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
        private int TypeWithJokers(string cards)
        {
            int maxScore = 0;
            char[] options = new char[] { '2', '3', '4', '5', '6', '7', '8', '9', 'T', 'Q', 'K', 'A' };
            foreach (char c in options)
            {
                maxScore = Math.Max(maxScore, TypeWithoutJokers(cards.Replace('J', c)));
            }
            return maxScore;
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
        public static Dictionary<char, int> JokerMapping = new Dictionary<char, int>()
        {
            { 'J', 0 },
            { '2', 1 },
            { '3', 2 },
            { '4', 3 },
            { '5', 4 },
            { '6', 5 },
            { '7', 6 },
            { '8', 7 },
            { '9', 8 },
            { 'T', 9 },
            { 'Q', 10 },
            { 'K', 11 },
            { 'A', 12 }
        };
        public static int CompareOrder(Hand hand1, Hand hand2, Dictionary<char, int> mapping)
        {
            int i = 0;
            char[] cards1 = hand1.Cards.ToCharArray();
            char[] cards2 = hand2.Cards.ToCharArray();
            while (i < hand1.Cards.Length)
            {
                if (mapping[cards1[i]] > mapping[cards2[i]]) return 1;
                else if (mapping[cards1[i]] < mapping[cards2[i]]) return -1;
                i++;
            }
            return 0;
        }
        public static Comparison<Hand> ComparerFactory(bool jokers)
        {
            Comparison<Hand> comparer = (hand1, hand2) =>
            {
                if (hand1.Type(jokers) > hand2.Type(jokers)) return 1;
                else if (hand1.Type(jokers) < hand2.Type(jokers)) return -1;
                else
                {
                    return CompareOrder(hand1, hand2, jokers ? JokerMapping : Mapping);
                }
            };
            return comparer;
        }

    }
}
