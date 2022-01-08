using Microsoft.AspNetCore.Mvc;

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
}