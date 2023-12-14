using Day_11;
using Utils;
// Load input

string input = InputLoader.LoadInput();
UniverseMap universe = new UniverseMap(input.Split('\n').SkipLast(1).ToList());

// Part One

List<int> emptyColumnsIds = new List<int>();
for (int i = 0; i < universe.Width; i++)
{
    if (universe.GetColumn(i).All(x => x == UniverseMap.EmptySpace)) emptyColumnsIds.Add(i);
}
/*List<int> emptyRowsIds = new List<int>();
for (int i = 0; i < universe.Height; i++)
{
    if (universe.GetRow(i).All(x => x == UniverseMap.EmptySpace)) emptyRowsIds.Add(i);
}*/

List<string> expandedMap = new List<string>();
for (int i = 0; i < universe.Height; i++)
{
    var row = universe.GetRow(i);
    for (int j = 0; j < emptyColumnsIds.Count; j++)
    {
        row.Insert(emptyColumnsIds[j] + j, UniverseMap.EmptySpace);
    }
    if (row.All(x => x == UniverseMap.EmptySpace)) expandedMap.Add(new string (row.ToArray()));
    expandedMap.Add (new string (row.ToArray()));
}

UniverseMap expandedUniverse = new UniverseMap(expandedMap);
ulong result = 0;
for (int i = 0; i < expandedUniverse.Galaxies.Count; i++)
{
    for (int j = i + 1; j < expandedUniverse.Galaxies.Count; j++)
    {
        result += (ulong)(Point2D.ManhattanDistance(expandedUniverse.Galaxies[i], expandedUniverse.Galaxies[j]));
    }
}
Console.WriteLine($"Part One answear: {result}");

// Part Two

result = 0;

Console.WriteLine($"Part Two answear: {result}");