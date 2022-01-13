using System.Net.Http.Json;
using ConsoleUI.Classes;
using Newtonsoft.Json;

namespace ConsoleUI.Api.Modules;

public class Employees
{
    private HttpClient http;
    
    public Employees(HttpClient httpClient)
    {
        this.http = httpClient;
    }

    public async Task<Employee[]?> All()
    {
        return JsonConvert.DeserializeObject<Employee[]>(
            await this.http.GetStringAsync("http://localhost:9002/v1/employees")
        );
    }
    
    public async Task<Employee?> Get(int id)
    {
        return JsonConvert.DeserializeObject<Employee>(
            await this.http.GetStringAsync("http://localhost:9002/v1/employees/" + id)
        );
    }
    
    public async Task<object?> Create(Employee employee)
    {
        var content = new {
            name = employee.Name,
            surname = employee.Surname,
            email = employee.Email,
            type = employee.Type,
            groupId = employee.GroupId,
        };
        var response = await this.http.PostAsJsonAsync("http://localhost:9002/v1/employees", content);
        return JsonConvert.DeserializeObject<object>(
            await response.Content.ReadAsStringAsync()
        );
    }
    
    public async Task<Employee?> Update(int id, Employee employee)
    {
        var content = new {
            name = employee.Name,
            surname = employee.Surname,
            email = employee.Email,
            type = employee.Type,
            groupId = employee.GroupId,
        };
        var response = await this.http.PutAsJsonAsync("http://localhost:9002/v1/employees/" + id, content);
        return JsonConvert.DeserializeObject<Employee>(
            await response.Content.ReadAsStringAsync()
        );
    }
}