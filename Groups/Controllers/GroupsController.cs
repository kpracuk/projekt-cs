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
        return new GroupDbEntities().Groups.ToList();
    }

    [HttpPost(Name = "CreateGroup")]
    public Group Post(Group group)
    {
        var groupDb = new GroupDbEntities();
        var groupEntity = groupDb.Add(group);
        groupDb.SaveChanges();
        return groupEntity.Entity;
    }
}