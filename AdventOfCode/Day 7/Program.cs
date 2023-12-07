using Day_7;
using Utils;
// Load input

string input = InputLoader.LoadInput();
List<Hand> hands = new List<Hand>();
foreach (var line in input.Split('\n').SkipLast(1))
{
    var tokens = line.Split(' ');
    hands.Add(new Hand(tokens[0], int.Parse(tokens[1])));
}

// Part One

hands.Sort(Hand.CompareHands);
ulong result = 0;
for (int i = 0; i < hands.Count; i++)
{
    result += (ulong)((i + 1) * hands[i].Value);
}

Console.WriteLine($"Part One answear: {result}");

// Part Two


Console.WriteLine($"Part Two answear: {result}");