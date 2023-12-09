using Day_8;
using Utils;
// Load input

string input = InputLoader.LoadInput();
var lines = input.Split('\n').SkipLast(1).ToList();

Navigation navigation = new Navigation(lines[0]);

HashSet<(string name, string left, string right)> instructions = new HashSet<(string name, string left, string right)>();
List<Node> nodes = new List<Node>();
for (int i = 2; i < lines.Count; i++)
{
    var toknes = lines[i].Replace("= (", "").Replace(")", "").Replace(",", "").Split(' ');
    instructions.Add((toknes[0], toknes[1], toknes[2]));
    nodes.Add(new Node(toknes[0]));
}

foreach (var instruction in instructions)
{
    Node current = nodes.Find(x => x.Name == instruction.name)!;
    Node left = nodes.Find(x => x.Name == instruction.left)!;
    Node right = nodes.Find(x => x.Name == instruction.right)!;
    current.AddNeighbours(left, right);
}

// Part One

(string start, string end) = ("AAA", "ZZZ");
int result = 0;
Node currentNode = nodes.Find(x => x.Name == "AAA")!;
while(navigation.MoveNext())
{
    currentNode = navigation.Current! == 'L' ? currentNode.Left! : currentNode.Right!;
    result++;
    if (currentNode.Name == end) break;
}

Console.WriteLine($"Part One answear: {result}");

// Part Two

bool ContainsCycle(List<int> stops)
{
    return stops.Count >= 3;
}

(int, int) GetCycleInfo(List<int> stops)
{
    return (stops[0], stops[2] - stops[1]);
}
ulong GCD(ulong a, ulong b)
{
    while(b != 0)
    {
        ulong t = b;
        b = a % b;
        a = t;
    }
    return a;
}

ulong LCM(ulong a, ulong b)
{
    return a / GCD(a, b) * b;
}

result = 0;
List<Node> currentNodes = nodes.FindAll(x => x.Name.EndsWith('A'));
List<(int start, int len)> cycles = new List<(int start, int len)>();
foreach(var cn in currentNodes)
{
    List<int> stops = new List<int>();
    navigation.Reset();
    int steps = 0;
    currentNode = cn;
    while (navigation.MoveNext() && !ContainsCycle(stops))
    {
        currentNode = navigation.Current! == 'L' ? currentNode.Left! : currentNode.Right!;
        steps++;
        if (currentNode.Name.EndsWith('Z')) stops.Add(steps);
    }
    cycles.Add(GetCycleInfo(stops));
}

ulong res = cycles.Select(x => (ulong)x.len).Aggregate((x, y) => LCM(x, y));

Console.WriteLine($"Part Two answear: {res}");