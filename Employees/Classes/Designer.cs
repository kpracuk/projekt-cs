using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Employees.Classes;

internal class DesignersDbEntities : DbContext
{
    public DbSet<Designer> Designers { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    { 
        optionsBuilder.UseSqlite("Filename=EmployeesDatabase.db");
    }
}

public class Designer
{
    [Key]
    public int Id { get; set; }
    
    public int EmployeeId { get; set; }
    public Employee Employee { get; set; }

    public string Type { get; set; } = "";
}