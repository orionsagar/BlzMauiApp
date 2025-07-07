using BlzMauiApp.Services.Data;

namespace BlzMauiApp;

public partial class App : Application
{
    //static LoginDatabase loginDatabase;
    public App()
    {
        InitializeComponent();

        MainPage = new MainPage();
    }

    //public static LoginDatabase database
    //{
    //    get
    //    {
    //        if (loginDatabase == null)
    //        {
    //            loginDatabase = new LoginDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "BenvueIntM.db3"));
    //        }
    //        return loginDatabase;
    //    }
    //}
}
