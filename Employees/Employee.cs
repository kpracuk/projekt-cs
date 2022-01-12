using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Employees.Classes;
using Microsoft.EntityFrameworkCore;

namespace Employees;

internal class EmployeeDbEntities : DbContext
{
    public DbSet<Employee> Employees { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    { 
        optionsBuilder.UseSqlite("Filename=EmployeesDatabase.db");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Devops>().ToTable("Devops");
        modelBuilder.Entity<Designer>().ToTable("Designers");
        modelBuilder.Entity<Frontend>().ToTable("Frontends");
        modelBuilder.Entity<Backend>().ToTable("Backends");
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