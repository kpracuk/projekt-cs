using Terminal.Gui;
using ConsoleUI.Api;
using ConsoleUI.Classes;

namespace ConsoleUI.Views.Groups;

public class CreateGroup : IAppView
{
    private Client api = new Client();

    private async Task<Group> PostGroup(Group group)
    {
        return await api.Groups.Create(group);
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

        var namelabel = new Label ("Nazwa: ") {
            X = 1,
            Y = 0,
            Width = 20,
            Height = 1
        };
        view.Add (namelabel);

        var name = new TextField ("") {
            X = 1,
            Y = 1,
            Width = 30,
            Height = 1,
            ColorScheme = Colors.Dialog
        };
        view.Add (name);
        
        var budgetLabel = new Label ("Budżet: ") {
            X = 1,
            Y = 3,
            Width = 20,
            Height = 1
        };
        view.Add (budgetLabel);

        var budget = new TextField ("") {
            X = 1,
            Y = 4,
            Width = 30,
            Height = 1,
            ColorScheme = Colors.Dialog
        };
        view.Add (budget);

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
            var group = new Group
            {
                Name = name.Text.ToString(),
                Budget = int.Parse(budget.Text.ToString())
            };
            await this.api.Groups.Create(group);
            view.RemoveAll();
            var success = new Label ("Dodano Projekt!") {
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