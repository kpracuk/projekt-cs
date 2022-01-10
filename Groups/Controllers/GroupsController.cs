using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Groups.Controllers;

[ApiController]
[Route("/v1/groups")]
public class GroupsController : ControllerBase
{
    [HttpGet(Name = "GetGroups")]
    public List<Group> Get()
    {
        Console.WriteLine("GET - /v1/groups");
        return new GroupDbEntities().Groups.ToList();
    }
    
    [HttpGet("{id}", Name = "GetGroup")]
    public ObjectResult Get(int id)
    {
        var group = new GroupDbEntities().Groups.Find(id);
        if (group == null)
        {
            return NotFound(group);
        }
        else
        {
            Console.WriteLine("GET - /v1/groups/" + id);
            return Ok(group);
        }
    }

    [HttpPost(Name = "CreateGroup")]
    public Group Post(Group group)
    {
        var groupDb = new GroupDbEntities();
        var groupEntity = groupDb.Add(group);
        groupDb.SaveChanges();
        Console.WriteLine("POST - /v1/groups");
        return groupEntity.Entity;
    }

    [HttpPut("{id}", Name = "GetGroup")]
    public ObjectResult Put(int id, Group group)
    {
        var groupDb = new GroupDbEntities();
        var currentGroup = groupDb.Groups.Find(id);
        if (currentGroup == null)
        {
            return NotFound(currentGroup);
        }

        currentGroup.Name = group.Name;
        currentGroup.Budget = group.Budget;
        groupDb.SaveChanges();
        Console.WriteLine("PUT - /v1/groups/" + id);
        return Ok(currentGroup);
    }
}