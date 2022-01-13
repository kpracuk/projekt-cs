using Terminal.Gui;
using ConsoleUI.Api;
using ConsoleUI.Classes;

namespace ConsoleUI.Views.Employees;

public class CreateEmployee : IAppView
{
    private Client api = new Client();

    private async Task<object> PostEmployee(Employee employee)
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
        view.Add(new Label ("Imię: ") {
            X = 1,
            Y = 0,
            Width = 20,
            Height = 1
        });
        var nameField = new TextField("")
        {
            X = 1,
            Y = 1,
            Width = 30,
            Height = 1,
            ColorScheme = Colors.Dialog
        };
        view.Add(nameField);
        
        view.Add(new Label ("Nazwisko: ") {
            X = 1,
            Y = 2,
            Width = 20,
            Height = 1
        });
        var surnameField = new TextField("")
        {
            X = 1,
            Y = 3,
            Width = 30,
            Height = 1,
            ColorScheme = Colors.Dialog
        };
        view.Add(surnameField);
        
        view.Add(new Label ("Email: ") {
            X = 1,
            Y = 4,
            Width = 20,
            Height = 1
        });
        var emailField = new TextField("")
        {
            X = 1,
            Y = 5,
            Width = 30,
            Height = 1,
            ColorScheme = Colors.Dialog
        };
        view.Add(emailField);
        
        view.Add(new Label ("Stanowisko: ") {
            X = 1,
            Y = 6,
            Width = 20,
            Height = 1
        });
        var typeField = new TextField("")
        {
            X = 1,
            Y = 7,
            Width = 30,
            Height = 1,
            ColorScheme = Colors.Dialog
        };
        view.Add(typeField);
        
        view.Add(new Label ("Projekt: ") {
            X = 1,
            Y = 8,
            Width = 20,
            Height = 1
        });
        var groupField = new TextField("")
        {
            X = 1,
            Y = 9,
            Width = 30,
            Height = 1,
            ColorScheme = Colors.Dialog
        };
        view.Add(groupField);

        var button = new Button("_Dodaj")
        {
            X = 1,
            Y = 11,
            Width = 30,
            Height = 1,
            ColorScheme = Colors.Dialog
        };
        button.Clicked += async () =>
        {
            var employee = new Employee
            {
                Name = nameField.Text.ToString(),
                Surname = surnameField.Text.ToString(),
                Email = emailField.Text.ToString(),
                Type = typeField.Text.ToString(),
                GroupId = int.Parse(groupField.Text.ToString())
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