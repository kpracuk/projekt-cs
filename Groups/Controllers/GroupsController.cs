using Microsoft.AspNetCore.Mvc;

namespace Groups.Controllers;

[ApiController]
[Route("/v1/groups")]
public class GroupsController : ControllerBase
{
    [HttpGet(Name = "GetGroups")]
    public IEnumerable<Group> Get()
    {
        return Enumerable.Range(1, 5).Select(index => new Group {
            Name = $"GroupName-{index}", 
            Budget = 10000, 
            Employees = new int[]{1, 3, 6}
        }).ToArray();
    }
}