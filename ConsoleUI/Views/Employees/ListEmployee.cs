using Terminal.Gui;
using ConsoleUI.Api;
using ConsoleUI.Classes;

namespace ConsoleUI.Views.Employees;

public class ListEmployees : IAppView
{
    private Client api = new Client();
    private Employee selectedEmployee;

    private async Task<Employee[]> GetEmployees()
    {
        return await api.Employees.All();
    }

    private View GenerateButton()
    {
        var button = new Button($"Edytuj - {this.selectedEmployee.Name} {this.selectedEmployee.Name}")
        {
            X = 1,
            Y = 11,
            Width = 30,
            Height = 1,
            ColorScheme = Colors.Dialog
        };
        button.Clicked += async () =>
        {
            var main = Main.GetInstance();
            var editEmployee = await new EditEmployee(this.selectedEmployee.Id).Render();
            main.RenderInContent(editEmployee);
        };

        return button;
    }
    
    public async Task<View> Render()
    {
        var view = new View()
        {
            X = 0,
            Y = 0,
            Width = Dim.Fill(),
            Height = Dim.Fill()
        };
        var employees = await this.GetEmployees();
        var list = new ListView(employees.ToList())
        {
            X = 0,
            Y = 0,
            Width = Dim.Fill(),
            Height = 10
        };
        list.MouseClick += args =>
        {
            this.selectedEmployee = employees[list.SelectedItem];
            view.Add(this.GenerateButton());
        };

        view.Add(list);
        return view;
    }
}