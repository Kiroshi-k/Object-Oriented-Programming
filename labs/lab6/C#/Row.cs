namespace TextLib;
public class Row
{
    private readonly string _data;
    public Row(string data = "") => _data = data;
    public string Data   => _data;
    public int    Length => _data.Length;
    public bool Contains(string sub) => _data.Contains(sub);
}
