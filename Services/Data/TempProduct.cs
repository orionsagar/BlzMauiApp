using BlzMauiApp.Helpers;
using BlzMauiApp.Models;
using SQLite;

namespace BlzMauiApp.Services.Data
{
    public class TempProduct
    {
        static SQLiteAsyncConnection Database => lazyInitializer.Value;
        static bool initialized = false;

        public TempProduct()
        {
            Task.Run(async () => await InitializeAsync());
        }


        static readonly Lazy<SQLiteAsyncConnection> lazyInitializer = new Lazy<SQLiteAsyncConnection>(() =>
        {
            return new SQLiteAsyncConnection(AppConfiguration.DatabasePath, AppConfiguration.Flags);
        });


        async Task InitializeAsync()
        {
            if (!initialized)
            {
                if (!Database.TableMappings.Any(m => m.MappedType.Name == typeof(UserInfo).Name))
                {
                    await Database.CreateTablesAsync(CreateFlags.None, typeof(UserInfo)).ConfigureAwait(false);
                    initialized = true;
                }
            }
        }


        public async Task<List<ProductInfo>> GetItemsAsync()
        {
            return await Database.Table<ProductInfo>().ToListAsync();
        }

        public async Task<int> GetTotalCountAsync()
        {
            return await Database.Table<ProductInfo>().CountAsync();
        }

        public async Task<List<ProductInfo>> GetItemsByIDAsync(string ID)
        {
            return await Database.QueryAsync<ProductInfo>("SELECT * FROM [ProductInfo] WHERE ProductID = " + Convert.ToInt32(ID) + "");
        }

        public async Task<List<ProductInfo>> GetItemsByEmailAsync(string Name)
        {
            return await Database.QueryAsync<ProductInfo>("SELECT * FROM [ProductInfo] WHERE ProductName ='" + Name + "'");
        }

        public async Task<ProductInfo> GetItemAsync(int id)
        {
            return await Database.Table<ProductInfo>().Where(i => Convert.ToInt32(i.ProductID) == id).FirstOrDefaultAsync();
        }

        public async Task<int> SaveItemAsync(ProductInfo item)
        {
            if (Convert.ToInt32(item.ProductID) != 0)
            {
                return await Database.UpdateAsync(item);
            }
            else
            {
                return await Database.InsertAsync(item);
            }
        }

        public async Task<int> DeleteItemAsync(ProductInfo item)
        {
            return await Database.DeleteAsync(item);
        }

        public Task<int> TruncateTableAsync()
        {
            return Database.ExecuteAsync("DELETE FROM [ProductInfo]");
        }
    }
}
