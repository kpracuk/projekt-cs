using ConsoleUI.Api.Modules;

namespace ConsoleUI.Api;

public class Client
{
    static readonly HttpClient client = new HttpClient();
    
    public Groups Groups = new Groups(client);
    public Employees Employees = new Employees(client);
}