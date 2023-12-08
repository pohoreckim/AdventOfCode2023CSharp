using Day_8;
using System.Collections.Generic;
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


Console.WriteLine($"Part Two answear: {result}");