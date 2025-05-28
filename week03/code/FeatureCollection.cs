public class FeatureCollection
{
    // TODO Problem 5 - ADD YOUR CODE HERE
    // Create additional classes as necessary


    public string Type { get; set; }
    public string Metadata { get; set; }
    public Data Features { get; set; }
}

public class Data
{
    public string Type { get; set; }
    public Prop Properties { get; set; }

}

public class Prop
{
    public string Mag { get; set; }
    public string Place { get; set; }

}