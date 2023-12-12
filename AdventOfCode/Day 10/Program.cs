using Day_10;
using Utils;
// Load input

Point2D north = new Point2D(0, -1);
Point2D south = new Point2D(0, 1);
Point2D east = new Point2D(1, 0);
Point2D west = new Point2D(-1, 0);   

Dictionary<char, (Point2D end1, Point2D end2)> pipes = new Dictionary<char, (Point2D end1, Point2D end2)>
{
    { '|', (north, south) },
    { '-', (east, west) },
    { 'L', (north, east) },
    { 'J', (north, west)},
    { '7', (south, west) },
    { 'F', (south, east) },
};

string input = InputLoader.LoadInput();
PipeMaze pipeMaze = new PipeMaze(input.Split('\n').SkipLast(1).ToArray());

// Part One

List<Point2D> directions = new List<Point2D>() { north, south, east, west };
List<Pipe> possibleStarts = new List<Pipe>();
directions.ForEach(x => possibleStarts.Add(new Pipe(x + pipeMaze.StartPosition, pipes[pipeMaze.GetChar(pipeMaze.StartPosition + x)])));
possibleStarts = possibleStarts.Where(x => x.EndsWith(pipeMaze.StartPosition)).ToList();
int[] counters = new int[2];
pipeMaze.SetDistance(0, pipeMaze.StartPosition);
for (int i = 0; i < possibleStarts.Count; i++)
{
    int counter = 1;
    Pipe current = possibleStarts[i];
    Point2D prev = pipeMaze.StartPosition;
    while(true)
    {
        pipeMaze.SetDistance(counter, current.Position);
        (Point2D nextPos, prev) = (current.ThroughPipe(prev), current.Position);
        char nextChar = pipeMaze.GetChar(nextPos);
        if (nextChar == PipeMaze.StartChar) { break; }
        current = new Pipe(nextPos, pipes[nextChar]);
        counter++;
    }
}

int result = pipeMaze.MaxDistance;
Console.WriteLine($"Part One answear: {result}");

// Part Two

pipeMaze.SetChar('J', pipeMaze.StartPosition);
string mazeSchematic = pipeMaze.ToString();
Console.WriteLine(mazeSchematic);
mazeSchematic = mazeSchematic.Replace("-", "").Replace("LJ","||").Replace("F7","||").Replace("L7","|").Replace("FJ","|");
Console.WriteLine(mazeSchematic);

result = 0;
string tmp = "";
foreach (var line in mazeSchematic.Split('\n').SkipLast(1))
{
    char[] chars = line.ToCharArray();
    bool isInside = false;
    for (int i = 0; i < chars.Length; i++)
    {
        if (chars[i] == PipeMaze.FreeTile && isInside)
        { 
            result++;
            chars[i] = 'I';
        }
        if (chars[i] == '|') isInside = !isInside;
    }
    tmp += new string(chars) + "\n";
}

Console.WriteLine(tmp);

Console.WriteLine($"Part Two answear: {result}");