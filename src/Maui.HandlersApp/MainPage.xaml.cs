namespace Maui.HandlersApp
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            var contentPage = new ContentPage();
            var contentView = new ContentView();

            contentPage.Content = new MyTreeView();

            var window = new Window();
            window.Page = contentPage;

            window.Destroying += Window_Destroying;

            Application.Current?.OpenWindow(window);
        }

        private void Window_Destroying(object? sender, EventArgs e)
        {
#if WINDOWS

            //if (sender is MauiWinUIWindow winUIWindow)
            //{
            //    winUIWindow.han
            //    if (platformView is MauiWinUIWindow mauiWinUIWindow)
            //        mauiWinUIWindow.SetWindow(null!);

            //    //TODO ancines Released mauiWinUIWindow
            //    if (windowRootContentManager != null)
            //    {
            //        var fieldInfo = windowRootContentManager.GetType().GetField("_platformWindow", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);
            //        if (fieldInfo != null)
            //            fieldInfo.SetValue(windowRootContentManager, null!);
            //    }
            //}
#endif
        }
    }
}
