using Day_3;
using Utils;

// Load input

string input = InputLoader.LoadInput();

// Part One

char[] symbols = { '#', '*', '+', '$', '@', '/', '%', '=', '&', '-'};
EngineSchematic engineSchematic = new EngineSchematic(input.TrimEnd());
var adjecentNumbers = engineSchematic.AdjecentNumbers(symbols);
HashSet<(int value, int y, int x)> numbers = new HashSet<(int value, int y, int x)>();
for (int i = 0; i < adjecentNumbers.Count; i++)
{
	foreach(var elem in adjecentNumbers[i])
	{
		numbers.Add(elem);
	}
}

int result = numbers.Select(x => x.value).Sum();
Console.WriteLine($"Part One answear: {result}");

// Part Two

var gears = engineSchematic.AdjecentNumbers(new char[] { '*' }).Where(x => x.Count == 2);
result = 0;
checked
{
	foreach (var gear in gears)
	{
		int mult = 1;
		foreach (var number in gear)
		{
			mult *= number.Item1;
		}
		result += mult;
	}
}

Console.WriteLine($"Part Two answear: {result}");