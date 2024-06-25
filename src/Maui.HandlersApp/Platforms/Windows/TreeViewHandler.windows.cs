using Microsoft.Maui.Handlers;
using Microsoft.UI.Xaml.Controls;

namespace Maui.HandlersApp;

public partial class TreeViewHandler : ViewHandler<MyTreeView, TreeView>
{
    public static IPropertyMapper<MyTreeView, TreeViewHandler> PropertyMapper = new PropertyMapper<MyTreeView, TreeViewHandler>(ViewHandler.ViewMapper)
    {
    };

    public static CommandMapper<MyTreeView, TreeViewHandler> CommandMapper = new(ViewCommandMapper)
    {
    };

    public TreeViewHandler() : base(PropertyMapper, CommandMapper)
    {
    }

    protected override void ConnectHandler(TreeView platformView)
    {
        platformView.Unloaded += PlatformView_Unloaded;
        base.ConnectHandler(platformView);
    }

    private void PlatformView_Unloaded(object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
    {
        if (sender is TreeView treeView)
            this.DisconnectHandler(treeView);
    }

    protected override void DisconnectHandler(TreeView platformView)
    {
        base.DisconnectHandler(platformView);
    }

    protected override TreeView CreatePlatformView()
    {
        var treeView = new TreeView()
        {
            AllowDrop = false,
            CanDrag = false
        };

        TreeViewNode workFolder = new TreeViewNode() { Content = "Work Documents" };
        workFolder.IsExpanded = true;

        workFolder.Children.Add(new TreeViewNode() { Content = "XYZ Functional Spec" });
        workFolder.Children.Add(new TreeViewNode() { Content = "Feature Schedule" });
        workFolder.Children.Add(new TreeViewNode() { Content = "Overall Project Plan" });
        workFolder.Children.Add(new TreeViewNode() { Content = "Feature Resources Allocation" });

        TreeViewNode remodelFolder = new TreeViewNode() { Content = "Home Remodel" };
        remodelFolder.IsExpanded = true;

        remodelFolder.Children.Add(new TreeViewNode() { Content = "Contractor Contact Info" });
        remodelFolder.Children.Add(new TreeViewNode() { Content = "Paint Color Scheme" });
        remodelFolder.Children.Add(new TreeViewNode() { Content = "Flooring woodgrain type" });
        remodelFolder.Children.Add(new TreeViewNode() { Content = "Kitchen cabinet style" });

        var personalFolder = new TreeViewNode() { Content = "Personal Documents" };
        personalFolder.IsExpanded = true;
        personalFolder.Children.Add(remodelFolder);

        treeView.RootNodes.Add(workFolder);
        treeView.RootNodes.Add(personalFolder);

        return treeView;
    }
}
