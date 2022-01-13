using Employees.Classes;
using Microsoft.AspNetCore.Mvc;

namespace Employees.Controllers;

[ApiController]
[Route("/v1/employees")]
public class EmployeesController : ControllerBase
{
    [HttpGet(Name = "GetEmployees")]
    public List<Employee> Get()
    {
        Console.WriteLine("GET - /v1/employees");
        return new EmployeeDbEntities().Employees.ToList();
    }
    
    [HttpGet("{id}", Name = "GetEmployee")]
    public ObjectResult Get(int id)
    {
        var employee = new EmployeeDbEntities().Employees.Find(id);
        if (employee == null)
        {
            return NotFound(employee);
        }
        else
        {
            Console.WriteLine("GET - /v1/employees/" + id);
            return Ok(employee);
        }
    }
    
    [HttpPost(Name = "CreateEmployee")]
    public bool Post(EmployeeRequest request)
    {
        var employeesDb = new EmployeeDbEntities();
        var newEmployee = new Employee()
        {
            Name = request.Name,
            Surname = request.Surname,
            Email = request.Email,
            Type = request.Type,
            GroupId = request.GroupId,
        };
        
        var employeeEntity = employeesDb.Add(newEmployee);
        
        employeesDb.SaveChanges();

        switch (request.Type)
        {
            case "designer":
            {
                var designerDb = new DesignersDbEntities();
                designerDb.Add(new Designer()
                {
                    Type = request.DesignerType,
                    EmployeeId = employeeEntity.Entity.Id
                });
                designerDb.SaveChanges();
                break;
            }
            case "devops":
            {
                var devopsDb = new DevopsDbEntities();
                devopsDb.Add(new Devops()
                {
                    Cloud = request.Cloud,
                    Level = request.Level,
                    EmployeeId = employeeEntity.Entity.Id
                });
                devopsDb.SaveChanges();
                break;
            }
            case "frontend":
            {
                var frontendDb = new FrontendDbEntities();
                frontendDb.Add(new Frontend()
                {
                    Language = request.Language,
                    Onsite = request.Onsite,
                    Level = request.Level,
                    EmployeeId = employeeEntity.Entity.Id
                });
                frontendDb.SaveChanges();
                break;
            }
            case "backend":
            {
                var backendDb = new BackendDbEntities();
                backendDb.Add(new Backend()
                {
                    Language = request.Language,
                    Onsite = request.Onsite,
                    Level = request.Level,
                    EmployeeId = employeeEntity.Entity.Id
                });
                backendDb.SaveChanges();
                break;
            }
        }
        Console.WriteLine("POST - /v1/employees");
        return true;
    }
    
    [HttpPut("{id}", Name = "UpdateEmployee")]
    public ObjectResult Put(int id, Employee employee)
    {
        var employeeDb = new EmployeeDbEntities();
        var currentEmployee = employeeDb.Employees.Find(id);
        if (currentEmployee == null)
        {
            return NotFound(currentEmployee);
        }
    
        currentEmployee.Name = employee.Name;
        currentEmployee.Surname = employee.Surname;
        currentEmployee.Email = employee.Email;
        currentEmployee.GroupId = employee.GroupId;
        currentEmployee.Type = employee.Type;
        employeeDb.SaveChanges();
        Console.WriteLine("PUT - /v1/employees/" + id);
        return Ok(currentEmployee);
    }
}