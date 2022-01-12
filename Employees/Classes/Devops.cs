using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Employees.Classes;

internal class DevopsDbEntities : DbContext
{
    public DbSet<Devops> Devops { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    { 
        optionsBuilder.UseSqlite("Filename=EmployeesDatabase.db");
    }
}

public class Devops
{
    [Key]
    public int Id { get; set; }
    
    public int EmployeeId { get; set; }
    public Employee Employee { get; set; }
    
    public bool Cloud { get; set; }
    
    public int Level { get; set; }
}