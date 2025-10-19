using Godot;
using SharpIDE.Application.Features.SolutionDiscovery;

namespace SharpIDE.Godot.Features.SolutionExplorer;

file enum FolderContextMenuOptions
{
    CreateNew = 1,
    RevealInFileExplorer = 2
}

file enum CreateNewSubmenuOptions
{
    Directory = 1,
    CSharpFile = 2
}

public partial class SolutionExplorerPanel
{
    private void OpenContextMenuFolder(SharpIdeFolder folder)
    {
        var menu = new PopupMenu();
        AddChild(menu);
        
        var createNewSubmenu = new PopupMenu();
        menu.AddSubmenuNodeItem("Add", createNewSubmenu, (int)FolderContextMenuOptions.CreateNew);
        createNewSubmenu.AddItem("Directory", (int)CreateNewSubmenuOptions.Directory);
        createNewSubmenu.AddItem("C# File", (int)CreateNewSubmenuOptions.CSharpFile);
        createNewSubmenu.IdPressed += OnCreateNewSubmenuPressed;
        
        menu.AddItem("Reveal in File Explorer", (int)FolderContextMenuOptions.RevealInFileExplorer);
        menu.PopupHide += () => menu.QueueFree();
        menu.IdPressed += id =>
        {
            var actionId = (FolderContextMenuOptions)id;
            if (actionId is FolderContextMenuOptions.RevealInFileExplorer)
            {
                OS.ShellOpen(folder.Path);
            }
        };
			
        var globalMousePosition = GetGlobalMousePosition();
        menu.Position = new Vector2I((int)globalMousePosition.X, (int)globalMousePosition.Y);
        menu.Popup();
    }

    private void OnCreateNewSubmenuPressed(long id)
    {
        var actionId = (CreateNewSubmenuOptions)id;
        if (actionId is CreateNewSubmenuOptions.Directory)
        {
            //OpenCreateNewFolderDialog(folder);
        }
        else if (actionId is CreateNewSubmenuOptions.CSharpFile)
        {
            //OpenCreateNewCSharpFileDialog(folder);
        }
    }
}