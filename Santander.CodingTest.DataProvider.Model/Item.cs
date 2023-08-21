namespace Santander.CodingTest.DataProvider.Model;

public record Item(string by, int descendants, int id, List<int> kids, int score, double time, string title, string type, string url);