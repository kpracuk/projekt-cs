using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Groups;

internal class GroupDbEntities : DbContext
{
    public DbSet<Group> Groups { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    { 
        optionsBuilder.UseSqlite("Filename=GroupsDatabase.db");
    }
}

public class Group
{
    [Key]
    public int Id { get; set; }
    
    public string Name { get; set; } = "";

    public int Budget { get; set; }
}