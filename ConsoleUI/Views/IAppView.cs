using Terminal.Gui;

namespace ConsoleUI.Views;

public interface IAppView
{
    public Task<View> Render();
}