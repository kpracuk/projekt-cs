using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Employees;

internal class EmployeeDbEntities : DbContext
{
    public DbSet<Employee> Employees { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    { 
        optionsBuilder.UseSqlite("Filename=EmployeesDatabase.db");
    }
}

public class Employee
{
    [Key]
    public int Id { get; set; }
    
    public string Name { get; set; } = "";
    
    public string Surname { get; set; } = "";
    
    public string Email { get; set; } = "";
    
    public string? Type { get; set; }

    public int? GroupId { get; set; }
}