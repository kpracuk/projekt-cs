using Terminal.Gui;
using ConsoleUI.Api;
using ConsoleUI.Classes;

namespace ConsoleUI.Views.Groups;

public class EditGroup : IAppView
{
    private Client api = new Client();

    private int groupId;

    public EditGroup(int id)
    {
        this.groupId = id;
    }

    public async Task<View> Render()
    {
        var currentGroup = await this.api.Groups.Get(this.groupId);
        
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
            Width = Dim.Fill(),
            Height = 1
        };
        view.Add (namelabel);

        var name = new TextField (currentGroup.Name) {
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
            Width = Dim.Fill(),
            Height = 1
        };
        view.Add (budgetLabel);

        var budget = new TextField (currentGroup.Budget.ToString()) {
            X = 1,
            Y = 4,
            Width = 30,
            Height = 1,
            ColorScheme = Colors.Dialog
        };
        view.Add (budget);

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
            currentGroup.Name = name.Text.ToString();
            currentGroup.Budget = int.Parse(budget.Text.ToString());
            await this.api.Groups.Update(this.groupId, currentGroup);
            view.RemoveAll();
            var success = new Label ("Zaktualizowano Projekt!") {
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