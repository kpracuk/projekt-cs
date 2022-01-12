namespace Employees;

public class EmployeeRequest
{
    public string Name { get; set; } = "";
    
    public string Surname { get; set; } = "";
    
    public string Email { get; set; } = "";
    
    public int? GroupId { get; set; }

    public string Type { get; set; } = "";
    
    public string Language { get; set; } = "";
    
    public int Level { get; set; }
    
    public bool Onsite { get; set; }
    
    public string DesignerType { get; set; } = "";
    
    public bool Cloud { get; set; }
}