using Terminal.Gui;
using ConsoleUI.Api;
using ConsoleUI.Classes;

namespace ConsoleUI.Views.Groups;

public class ListGroups : IAppView
{
    private Client api = new Client();

    private async Task<Group[]> GetGroups()
    {
        return await api.Groups.All();
    }
    
    public async Task<View> Render()
    {
        var groups = await this.GetGroups();
        return new ListView(groups.ToList())
        {
            X = 0,
            Y = 0,
            Width = Dim.Fill(),
            Height = Dim.Fill()
        };
    }
}