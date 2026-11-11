using System.IO;

var groups = new Dictionary<string, (string MinWord, int Count)>();

foreach (var line in File.ReadLines("input.txt"))
{
    var word = line.Trim();
    if (word.Length == 0) continue;

    var chars = word.ToCharArray();
    Array.Sort(chars);
    var key = new string(chars);

    if (groups.TryGetValue(key, out var val))
        groups[key] = (string.CompareOrdinal(word, val.MinWord) < 0 ? word : val.MinWord, val.Count + 1);
    else
        groups[key] = (word, 1);
}

var ordered = groups.Values.OrderBy(g => g.MinWord, StringComparer.Ordinal);

using var writer = new StreamWriter("output.txt");
foreach (var (word, count) in ordered)
{
    writer.WriteLine($"{word} {count}");
}
