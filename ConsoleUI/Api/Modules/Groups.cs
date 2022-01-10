using System.Net.Http.Json;
using System.Text;
using ConsoleUI.Classes;
using Newtonsoft.Json;

namespace ConsoleUI.Api.Modules;

public class Groups
{
    private HttpClient http;
    
    public Groups(HttpClient httpClient)
    {
        this.http = httpClient;
    }

    public async Task<Group[]?> All()
    {
        return JsonConvert.DeserializeObject<Group[]>(
            await this.http.GetStringAsync("http://localhost:9001/v1/groups")
        );
    }
    
    public async Task<Group?> Get(int id)
    {
        return JsonConvert.DeserializeObject<Group>(
            await this.http.GetStringAsync("http://localhost:9001/v1/groups/" + id)
        );
    }
    
    public async Task<Group?> Create(Group group)
    {
        var content = new {
            name = group.Name,
            budget = group.Budget
        };
        var response = await this.http.PostAsJsonAsync("http://localhost:9001/v1/groups", content);
        return JsonConvert.DeserializeObject<Group>(
            await response.Content.ReadAsStringAsync()
        );
    }
    
    public async Task<Group?> Update(int id, Group group)
    {
        var content = new {
            name = group.Name,
            budget = group.Budget
        };
        var response = await this.http.PutAsJsonAsync("http://localhost:9001/v1/groups/" + id, content);
        return JsonConvert.DeserializeObject<Group>(
            await response.Content.ReadAsStringAsync()
        );
    }
}