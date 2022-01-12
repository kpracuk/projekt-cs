using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Employees.Classes;

internal class BackendDbEntities : DbContext
{
    public DbSet<Backend> Backends { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    { 
        optionsBuilder.UseSqlite("Filename=EmployeesDatabase.db");
    }
}

public class Backend
{
    [Key]
    public int Id { get; set; }
    
    public int EmployeeId { get; set; }
    public Employee Employee { get; set; }

    public string Language { get; set; } = "";
    
    public int Level { get; set; }
    
    public bool Onsite { get; set; }
}