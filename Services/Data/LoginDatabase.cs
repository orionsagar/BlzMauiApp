using BlzMauiApp.Helpers;
using BlzMauiApp.Models;
using SQLite;

namespace BlzMauiApp.Services.Data
{
    public class LoginDatabase //: ILoginDatabase
    {
        string _dbPath;
        public string StatusMessage { get; set; }
        private SQLiteAsyncConnection connection;

        //public LoginDatabase(string dbPath)
        //{
        //    connection = new SQLiteAsyncConnection(dbPath);
        //    connection.CreateTableAsync<UserInfo>();
        //}

        public LoginDatabase()
        {
            Task.Run(async () => await InitAsync());
            //InitAsync();
        }

        public async Task InitAsync()
        {
            if (connection == null)
            {
                string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "BenvueIntM.db3");
                connection = new SQLiteAsyncConnection(dbPath);
                await connection.CreateTableAsync<UserInfo>();
            }

            //connection = new SQLiteAsyncConnection(_dbPath);
            //await connection.CreateTableAsync<UserInfo>().ConfigureAwait(false);
        }




        //static SQLiteAsyncConnection Database => lazyInitializer.Value;
        //static bool initialized = false;
        //public LoginDatabase()
        //{
        //    Task.Run(async () => await InitializeAsync());
        //}

        //static readonly Lazy<SQLiteAsyncConnection> lazyInitializer = new Lazy<SQLiteAsyncConnection>(() =>
        //{
        //    return new SQLiteAsyncConnection(AppConfiguration.DatabasePath, AppConfiguration.Flags);
        //});

        //async Task InitializeAsync()
        //{
        //    if (!initialized)
        //    {
        //        if (!Database.TableMappings.Any(m => m.MappedType.Name == typeof(UserInfo).Name))
        //        {
        //            await Database.CreateTablesAsync(CreateFlags.None, typeof(UserInfo)).ConfigureAwait(false);
        //            initialized = true;
        //        }
        //    }
        //}


        public async Task<List<UserInfo>> GetItemsAsync()
        {
            return await connection.Table<UserInfo>().ToListAsync();
        }

        public async Task<int> GetTotalCountAsync()
        {
            return await connection.Table<UserInfo>().CountAsync();
        }

        public async Task<List<UserInfo>> GetItemsByIDAsync(string LocalLoginID)
        {
            return await connection.QueryAsync<UserInfo>("SELECT * FROM [UserInfo] WHERE userID = " + Convert.ToInt32(LocalLoginID) + "");
        }

        public async Task<List<UserInfo>> GetItemsByEmailAsync(string Username)
        {
            return await connection.QueryAsync<UserInfo>("SELECT * FROM [UserInfo] WHERE Username ='" + Username + "'");
        }

        public async Task<UserInfo> GetItemAsync(int id)
        {
            return await connection.Table<UserInfo>().Where(i => Convert.ToInt32(i.userID) == id).FirstOrDefaultAsync();
        }

        public async Task<int> SaveItemAsync(UserInfo item)
        {
            if (Convert.ToInt32(item.LocalLoginID) != 0)
            {
                return await connection.UpdateAsync(item);
            }
            else
            {
                return await connection.InsertAsync(item);
            }
        }

        public async Task<int> DeleteItemAsync(UserInfo item)
        {
            return await connection.DeleteAsync(item);
        }

        public Task<int> TruncateTableAsync()
        {
            return connection.ExecuteAsync("DELETE FROM [UserInfo]");
        }
    }
}
