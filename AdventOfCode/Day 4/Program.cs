using Utils;

// Load input

string input = InputLoader.LoadInput();

// Part One

int result = 0;
foreach (var line in input.Split('\n').SkipLast(1))
{
    string[] card = line.Substring(line.IndexOf(':') + 1).Split('|');
    List<int> winningNumbers = new List<int>();
    List<int> pickedNumbers = new List<int>();
    foreach (var number in card[0].Split(' '))
    {
        if (int.TryParse(number, out int  winningNumber)) winningNumbers.Add(winningNumber);
    }
    foreach (var number in card[1].Split(' '))
    {
        if (int.TryParse(number, out int pickedNuber)) pickedNumbers.Add(pickedNuber);
    }
    int k = pickedNumbers.Intersect(winningNumbers).Count();
    result += k > 0 ? 1 << (k - 1) : 0;
}

Console.WriteLine($"Part One answear: {result}");

// Part Two


Console.WriteLine($"Part Two answear: {result}");