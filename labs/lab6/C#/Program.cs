using TextLib;

var txt = new Text();
txt.AddRow(new Row("Hello, student!"));
txt.AddRow(new Row("Object Oriented Programming"));
txt.AddRow(new Row("Kyiv Aviation University"));

Console.WriteLine($"Avg length: {txt.AverageRowLength():F2}");
Console.WriteLine($"Vowel % :   {txt.TotalVowelPercentage():F2}");

txt.RemoveRowsWithSubstring("Kyiv");
Console.WriteLine($"After removal, rows: {txt.AverageRowLength():F2}");
