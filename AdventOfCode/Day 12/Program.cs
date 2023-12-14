using Utils;
// Load input

string input = InputLoader.LoadInput();

// Part One

const char damaged = '#';
const char operational = '.';
const char unknown = '?';

Func<char[], List<int>> springsLen = (springsString) =>
{
    int len = 0;
    List<int> springsLen = new List<int>();
    foreach (var springChar in springsString)
    {
        if (springChar == damaged) len++;
        else if (len > 0)
        {
            springsLen.Add(len);
            len = 0;
        }
    }
    if (len > 0) springsLen.Add(len);
    return springsLen;
};

Func<List<int>, List<int>, bool> listEquality = (firstList, secondList) =>
{
    if (firstList.Count != secondList.Count) return false;
    for (int i = 0; i < firstList.Count; i++)
    {
        if (firstList[i] != secondList[i]) return false;
    }
    return true;
};

int Func(char[] springs, List<int> goal)
{
    int index = -1;
    for (int i = 0; i < springs.Length; i++)
    {
        if (springs[i] == unknown)
        {
            index = i; break;
        }
    }
    if (index < 0) 
    {
        return listEquality(goal, springsLen(springs)) ? 1 : 0;
    }
    else
    {
        (char[] firstOption, char[] secondOption) = ((char[])springs.Clone(), (char[])springs.Clone());
        (firstOption[index], secondOption[index]) = (damaged, operational);
        return Func(firstOption, goal) + Func(secondOption, goal);
    }
}


int result = 0;
foreach (var line in input.Split('\n').SkipLast(1))
{
    var informations = line.Split(" ");
    List<int> lengths = informations[1].Split(",").Select(x => int.Parse(x)).ToList();
    //List<string> unknowns = informations[0].Split('.').Where(x => x.Length > 0).ToList();
    result += Func(informations[0].ToCharArray(), lengths);
}

Console.WriteLine($"Part One answear: {result}");

// Part Two

result = 0;

Console.WriteLine($"Part Two answear: {result}");