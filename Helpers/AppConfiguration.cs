namespace BlzMauiApp.Helpers
{
    public class AppConfiguration
    {
        //public static string BaseApiAddress => "https://api.example.com/";
        public static string BaseApiAddress => "https://api.example.xyz/";
        public static string BaseApiImgAddress => "https://api.example.xyz/";
        public static string AccessName = "Bearer";
        public static string AccessToken = "kR6Y6S13g9467E9SiXBsbLuIVuaMLnzxFQyLVhOiosr1M4zQCU_PaOg6I_K8tc_DeroM1yQTJ__tSkQbkeXa1gM6Vn0mvLLyArra6sTlQu0uB7gXH7B0KrgYK123Scvc4q0r-JZOJ89wRdhyogk8YjpWc8BFaP4q4qiaQLV-eNTKgyWXad_DlWkudt7RVyvj0F2Ndvns_V8W12pO1LH9GM9mMWSGTX8iRtqF3qsGTbZcfU_hGU2R1ZwsGb3cGoytyZFl31liuP08AsEuWGO7X1P30t34imqUL4K7mWVOCg2hCw11";


        /// <summary>
        /// SMS Config
        /// </summary>
        public static string SMSApiToken = "8da3b9c7-dde6-4580-98e0-43783592fec8";
        public static string SMSApiSID = "BlzMauiApp";



        /// <summary>
        /// Local Database Configuration
        /// </summary>
        public const string DatabaseFilename = "BlzMauiApp.db3";

        public const SQLite.SQLiteOpenFlags Flags =
            // open the database in read/write mode
            SQLite.SQLiteOpenFlags.ReadWrite |
            // create the database if it doesn't exist
            SQLite.SQLiteOpenFlags.Create |
            // enable multi-threaded database access
            SQLite.SQLiteOpenFlags.SharedCache;

        public static string DatabasePath
        {
            get
            {
                var basePath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                return Path.Combine(basePath, DatabaseFilename);
            }
        }
    }
}
