using Terminal.Gui;
using ConsoleUI.Api;
using ConsoleUI.Classes;

namespace ConsoleUI.Views.Groups;

public class ListGroups : IAppView
{
    private Client api = new Client();
    private Group selectedGroup;

    private async Task<Group[]> GetGroups()
    {
        return await api.Groups.All();
    }

    private View GenerateButton()
    {
        var button = new Button("Edytuj - " + this.selectedGroup.Name)
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
            var editGroup = await new EditGroup(this.selectedGroup.Id).Render();
            main.RenderInContent(editGroup);
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
        var groups = await this.GetGroups();
        var list = new ListView(groups.ToList())
        {
            X = 0,
            Y = 0,
            Width = Dim.Fill(),
            Height = 10
        };
        list.MouseClick += args =>
        {
            this.selectedGroup = groups[list.SelectedItem];
            view.Add(this.GenerateButton());
        };

        view.Add(list);
        return view;
    }
}