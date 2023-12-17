using Utils;
// Load input

string input = InputLoader.LoadInput();

// Part One

int divisor = 256;
int multiplier = 17;

Func<string, int> toHash = (x) =>
{
    return x.ToCharArray().Aggregate(0, (a, b) => ((a + b) * multiplier) % divisor);
};
var tokens = input.Trim().Split(',');
int result = tokens.Select(x => toHash(x)).Sum();

Console.WriteLine($"Part One answear: {result}");

// Part Two

List<(string label, int focalLength)>[] boxes = new List<(string label, int focalLength)>[divisor];
for (int i = 0; i < boxes.Length; i++)
{
    boxes[i] = new List<(string label, int focalLength)>();
}
foreach (var token in tokens)
{
    char operation = token.Contains('-') ? '-' : token.Contains('=') ? '=' : '=';
    var parts = token.Replace(operation, ' ').Split(' ');
    int hash = toHash(parts[0]);
    int index = boxes[hash].FindIndex(x => x.label == parts[0]);
    switch (operation)
    {
        case '-':
            if (index >= 0) boxes[hash].RemoveAt(index);
            break;
        case '=':
            (string, int) tuple = (parts[0], int.Parse(parts[1]));
            if (index >= 0) boxes[hash][index] = tuple;
            else boxes[hash].Add(tuple);
            break;
        default:
            break;
    }
}

result = 0;
for (int i = 0; i < boxes.Length; i++)
{
    for (int j = 0; j < boxes[i].Count; j++)
    {
        result += (i + 1) * (j + 1) * boxes[i][j].focalLength;
    }
}


Console.WriteLine($"Part Two answear: {result}");