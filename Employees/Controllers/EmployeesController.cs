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
    public Employee Post(Employee employee)
    {
        var employeeDb = new EmployeeDbEntities();
        var employeeEntity = employeeDb.Add(employee);
        employeeDb.SaveChanges();
        Console.WriteLine("POST - /v1/employees");
        return employeeEntity.Entity;
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