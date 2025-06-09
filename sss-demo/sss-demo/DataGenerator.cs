namespace sss_demo;

public static class DataGenerator
{
    public static MockDataModel CreateMockData()
    {
        var random = new Random();

        return new MockDataModel
        {
            Identifier = Guid.NewGuid(),
            Random = random.Next(10)
        };
    }
}

public class MockDataModel
{
    public Guid Identifier { get; set; }
    public int Random { get; set; }
}