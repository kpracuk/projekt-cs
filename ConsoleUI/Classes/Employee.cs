namespace ConsoleUI.Classes;

public class Employee
{
    public int Id { get; set; }

    public string Name { get; set; } = "";

    public string Surname { get; set; } = "";

    public string Email { get; set; } = "";

    public string? Type { get; set; }

    public int? GroupId { get; set; }
    
    public override string ToString()
    {
        return $"{this.Id} - {this.Name} {this.Surname} <{this.Email}>";
    }
}