using Terminal.Gui;
using ConsoleUI.Views.Groups;
using ConsoleUI.Views.Employees;

namespace ConsoleUI.Views;

public sealed class Main
{
    private Toplevel app;
    private View content;
    private static Main _instance;
    
    public static Main GetInstance()
    {
        if (_instance == null)
        {
            _instance = new Main();
        }
        return _instance;
    }
    
    private Main()
    {
        app = Application.Top;
        content = new View {
            X = 0,
            Y = 1,
            Height = Dim.Fill(),
            Width = Dim.Fill()
        };
    }
    
    public void RenderInContent(View view) {
        content.RemoveAll();
        content.Add(view);
    }
    
    public void Run()
    {
        var menu = new MenuBar(new[] {
            new MenuBarItem ("Projekty", new[] {
                new MenuItem ("Lista", "", async () =>
                {
                    var view = await new ListGroups().Render();
                    RenderInContent(view);
                }),
                new MenuItem ("Dodaj", "", async () =>
                {
                    var view = await new CreateGroup().Render();
                    RenderInContent(view);
                })
            }),
            new MenuBarItem ("Pracownicy", new[] {
                new MenuItem ("Lista ", "", async () =>
                {
                    var view = await new ListEmployees().Render();
                    RenderInContent(view);
                }),
                new MenuItem ("Dodaj", "", async () =>
                {
                    var view = await new CreateEmployee().Render();
                    RenderInContent(view);
                })
            })
        });

        app.Add(menu);
        app.Add(content);
    }
}