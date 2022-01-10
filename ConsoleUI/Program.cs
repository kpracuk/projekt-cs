using Terminal.Gui;
using ConsoleUI.Views.Groups;

Application.Init();

var content = new View {
    X = 0,
    Y = 1,
    Height = Dim.Fill(),
    Width = Dim.Fill()
};

var menu = new MenuBar(new[] {
    new MenuBarItem ("Projekty", new[] {
        new MenuItem ("Lista", "", async () =>
        {
            var view = await new ListGroups().Render();
            RenderInContent(view);
        }),
        new MenuItem ("Dodaj", "", null)
    })
});

void RenderInContent(View view) {
    content.RemoveAll();
    content.Add(view);
}

var app = Application.Top;

app.Add(menu);
app.Add(content);

Application.Run();
