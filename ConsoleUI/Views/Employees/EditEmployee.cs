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
        view.Add(new Label ("Imię: ") {
            X = 1,
            Y = 0,
            Width = 20,
            Height = 1
        });
        var nameField = new TextField(currentEmployee.Name)
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
        var surnameField = new TextField(currentEmployee.Surname)
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
        var emailField = new TextField(currentEmployee.Email)
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
        var typeField = new TextField(currentEmployee.Type)
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
        var groupField = new TextField(currentEmployee.GroupId.ToString())
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
            currentEmployee.Name = nameField.Text.ToString();
            currentEmployee.Surname = surnameField.Text.ToString();
            currentEmployee.Email = emailField.Text.ToString();
            currentEmployee.Type = typeField.Text.ToString();
            currentEmployee.GroupId = int.Parse(groupField.Text.ToString());
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