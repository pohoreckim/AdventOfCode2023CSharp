using Day_14;
using Utils;
// Load input

string input = InputLoader.LoadInput();

// Part One

int result = 0;
Platform platform = new Platform(input.Trim().Split('\n'));
platform.MoveStones(new Point2D(0, -1));
result += platform.Weight;
Console.WriteLine($"Part One answear: {result}");

// Part Two

List<int> PossibleCycle(List<(int weight, int moves)> history)
{
    var counts = history.GroupBy(x => x).Select(x => (x.Key, Counts: x.Count())).Where(x => x.Counts >= 3);
    foreach (var count in counts)
    {
        var indexes = history
            .Select((value, index) => (value, index))
            .Where(x => x.value == count.Key)
            .ToList();
        var len = indexes.Count() - 1;
        if (indexes[len].index - indexes[len - 1].index == indexes[len - 1].index - indexes[len - 2].index)
            return indexes.Select(x => x.index).ToList();
    }
    return new List<int>();
}

int numCycles = 1_000_000_000;
platform = new Platform(input.Trim().Split('\n'));
List<(int weight, int moves)> history = new List<(int, int)>();
List<int> cycle = new List<int>();
// NOT PERFECT BUT WORKS
for (int i = 0; i < numCycles; i++)
{
    int movedStones = platform.Cycle();
    history.Add((platform.Weight, movedStones));
    cycle = PossibleCycle(history);
    if (cycle.Count > 0)
    {
        break;
    }
}
int offset = cycle[0] + 1;
int cycleLen = cycle[2] - cycle[1];
int times = (numCycles - offset) / cycleLen;
int cyclesLeft =  numCycles - times * cycleLen;
result = history[cyclesLeft - 1].weight;

Console.WriteLine($"Part Two answear: {result}");