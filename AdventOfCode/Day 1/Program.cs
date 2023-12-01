using Utils;

// Load input

string input = InputLoader.LoadInput();

// Part One

int Func(string s)
{
    int result = 0;
    foreach (var line in s.Split('\n').SkipLast(1))
    {
        char[] numbers = line.ToArray().Where(x => int.TryParse(x.ToString(), out _)).ToArray();
        result += int.Parse(numbers[0].ToString() + numbers[numbers.Length - 1]);
    }
    return result;
}

//int result = 0;
int result = Func(input);

Console.WriteLine($"Part One answear: {result}");

// Part Two

Dictionary<string, string> literals = new Dictionary<string, string>()
{
    { "one", "o1e"},
    { "two", "t2o"},
    { "three", "t3e"},
    { "four", "f4r"},
    { "five", "f5e"},
    { "six", "s6x" },
    { "seven", "s7n" },
    { "eight", "e8t" },
    { "nine", "n9e" }
};

string withSpelledLetters = input;
foreach (var key in literals.Keys)
{
    withSpelledLetters = withSpelledLetters.Replace(key, literals[key]);
}

result = Func(withSpelledLetters);

Console.WriteLine($"Part Two answear: {result}");