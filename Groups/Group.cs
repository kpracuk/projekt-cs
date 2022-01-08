namespace Groups;

public class Group
{
    public string Name { get; set; } = "";

    public int Budget { get; set; }

    public int[] Employees { get; set; } = Array.Empty<int>();
}