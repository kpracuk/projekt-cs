namespace ConsoleUI.Classes;

public class Group
{
    public int Id { get; set; }
    
    public string Name { get; set; } = "";

    public int Budget { get; set; }

    public override string ToString()
    {
        return $"{this.Id} - {this.Name}";
    }
}