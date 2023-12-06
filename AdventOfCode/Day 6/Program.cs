using Utils;
// Load input

string input = InputLoader.LoadInput();
var lines = input.Split('\n').SkipLast(1);
List<List<int>> data = new List<List<int>>();   
foreach (var line in lines)
{
     data.Add(line.Split(' ').Where(x => int.TryParse(x, out _)).Select(x => int.Parse(x)).ToList());
}
List<(int time, int distance)> races = data[0].Zip(data[1]).ToList();

// Part One

Func<int, int, ulong> calcDistance = (raceTime, chargingTime) => { return (ulong)(raceTime - chargingTime) * (ulong)(chargingTime); };
int CountWays(int time, ulong distance)
{
    int counter = 0;
    int half = time / 2;
    (int i, int j) = (0, 1);
    while (half - i > 0)
    {
        if (calcDistance(time, half - i) < distance) break;
        else counter++;
        i++;
    }
    while (half + j < time)
    {
        if (calcDistance(time, half + j) < distance) break;
        else counter++;
        j++;
    }
    return counter;
}

int result = 1;
foreach (var race in races)
{
    result *= CountWays(race.time, (ulong)race.distance);
}

Console.WriteLine($"Part One answear: {result}");

// Part Two

int time = int.Parse(string.Join(null, data[0].Select(x => x.ToString())));
ulong distance = ulong.Parse(string.Join(null, data[1].Select(x => x.ToString())));
result = CountWays(time, distance);

Console.WriteLine($"Part Two answear: {result}");