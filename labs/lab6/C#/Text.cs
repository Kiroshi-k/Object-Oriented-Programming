using System.Text;
namespace TextLib;

public class Text : IVowelWorker
{
    private readonly List<Row> _rows = new();

    private static bool IsVowel(char ch)
    {
        const string vowels = "aeiouAEIOUаеєиіоуюяАЕЄИІОУЮЯ";
        return vowels.Contains(ch);
    }

    // --- IVowelWorker ---
    public int CountVowels(string s) => s.Count(IsVowel);

    public double VowelPercentage(string s)
    {
        int letters = s.Count(char.IsLetter);
        int vowels  = CountVowels(s);
        return letters == 0 ? 0 : 100.0 * vowels / letters;
    }

    // --- керування рядками ---
    public void AddRow(Row r) => _rows.Add(r);
    public bool RemoveRow(int idx)
    {
        if (idx < 0 || idx >= _rows.Count) return false;
        _rows.RemoveAt(idx);
        return true;
    }
    public void Clear() => _rows.Clear();

    public bool RemoveRowsWithSubstring(string sub)
    {
        int before = _rows.Count;
        _rows.RemoveAll(r => r.Contains(sub));
        return before != _rows.Count;
    }

    // --- статистика ---
    public double AverageRowLength() =>
        _rows.Count == 0 ? 0 : _rows.Average(r => r.Length);

    public double TotalVowelPercentage()
    {
        int letters = 0, vowels = 0;
        foreach (var r in _rows)
        {
            letters += r.Data.Count(char.IsLetter);
            vowels  += CountVowels(r.Data);
        }
        return letters == 0 ? 0 : 100.0 * vowels / letters;
    }
}
