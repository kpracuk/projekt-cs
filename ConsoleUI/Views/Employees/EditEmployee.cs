using Terminal.Gui;
using ConsoleUI.Api;
using ConsoleUI.Classes;

namespace ConsoleUI.Views.Employees;

public class EditEmployee : IAppView
{
    private Client api = new Client();

    private int employeeId;

    public EditEmployee(int id)
    {
        this.employeeId = id;
    }

    public async Task<View> Render()
    {
        var currentEmployee = await this.api.Employees.Get(this.employeeId);
        
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
        
        var values = new Dictionary<string, string>
        {
            {"name", currentEmployee.Name},
            {"surname", currentEmployee.Surname},
            {"email", currentEmployee.Email}
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

            inputs[field.Key] = new TextField(values[field.Key])
            {
                X = 1,
                Y = 2 * i + 1,
                Width = 30,
                Height = 1,
                ColorScheme = Colors.Dialog
            };
            view.Add(inputs[field.Key]);
        }


        var button = new Button("_Zaktualizuj")
        {
            X = 1,
            Y = 7,
            Width = 30,
            Height = 1,
            ColorScheme = Colors.Dialog
        };
        button.Clicked += async () =>
        {
            currentEmployee.Name = inputs["name"].Text.ToString();
            currentEmployee.Surname = inputs["surname"].Text.ToString();
            currentEmployee.Email = inputs["email"].Text.ToString();
            await this.api.Employees.Update(this.employeeId, currentEmployee);
            view.RemoveAll();
            var success = new Label ("Zaktualizowano Pracownika!") {
                X = 1,
                Y = 1,
                Width = Dim.Fill(),
                Height = 1
            };
            view.Add(success);
        };
        view.Add(button);
        
        return view;
    }
}