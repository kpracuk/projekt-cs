using Terminal.Gui;
using ConsoleUI.Api;
using ConsoleUI.Classes;

namespace ConsoleUI.Views.Employees;

public class CreateEmployee : IAppView
{
    private Client api = new Client();

    private async Task<Employee> PostEmployee(Employee employee)
    {
        return await api.Employees.Create(employee);
    }
    
    public async Task<View> Render()
    {
        var view = new View()
        {
            X = 0,
            Y = 1,
            Width = Dim.Fill(),
            Height = Dim.Fill()
        };

        var fields = new Dictionary<string, string>
        {
            {"name", "Imię: "},
            {"surname", "Nazwisko: "},
            {"email", "Email: "}
        };
        
        var inputs = new Dictionary<string, View?>
        {
            {"name", null},
            {"surname", null},
            {"email", null}
        };

        for (int i = 0; i < inputs.Count; i++)
        {
            var field = fields.ElementAt(i);
            view.Add(new Label (field.Value) {
                X = 1,
                Y = 2 * i,
                Width = 20,
                Height = 1
            });
            inputs[field.Key] = new TextField("")
            {
                X = 1,
                Y = 2 * i + 1,
                Width = 30,
                Height = 1,
                ColorScheme = Colors.Dialog
            };
            view.Add(inputs[field.Key]);
        }

        var button = new Button("_Dodaj")
        {
            X = 1,
            Y = 7,
            Width = 30,
            Height = 1,
            ColorScheme = Colors.Dialog
        };
        button.Clicked += async () =>
        {
            var employee = new Employee
            {
                Name = inputs["name"].Text.ToString(),
                Surname = inputs["name"].Text.ToString(),
                Email = inputs["name"].Text.ToString(),
            };
            await this.api.Employees.Create(employee);
            view.RemoveAll();
            var success = new Label ("Dodano Pracownika!") {
                X = 1,
                Y = 1,
                Width = 20,
                Height = 1
            };
            view.Add(success);
        };
        view.Add(button);
        
        return view;
    }
}