using Day_4;
using Utils;

// Load input

string input = InputLoader.LoadInput();
List<Card> cards = new List<Card>();
foreach (var line in input.Split('\n').SkipLast(1))
{
    string[] card = line.Substring(line.IndexOf(':') + 1).Split('|');
    List<int> winningNumbers = new List<int>();
    List<int> pickedNumbers = new List<int>();
    foreach (var number in card[0].Split(' '))
    {
        if (int.TryParse(number, out int winningNumber)) winningNumbers.Add(winningNumber);
    }
    foreach (var number in card[1].Split(' '))
    {
        if (int.TryParse(number, out int pickedNuber)) pickedNumbers.Add(pickedNuber);
    }
    cards.Add(new Card(winningNumbers.ToArray(), pickedNumbers.ToArray()));
}


// Part One

int result = 0;
foreach (var card in cards)
{
    int k = card.MatchingNumers.Length;
    result += k > 0 ? 1 << (k - 1) : 0;
}

Console.WriteLine($"Part One answear: {result}");

// Part Two

int[] cardCounts = Enumerable.Repeat(1, cards.Count).ToArray();
for (int i = 0; i < cards.Count; i++)
{
    for (int j = i + 1; j <= i + cards[i].MatchingNumers.Length; j++)
    {
        cardCounts[j] += cardCounts[i];
    }
}
result = cardCounts.Sum();

Console.WriteLine($"Part Two answear: {result}");