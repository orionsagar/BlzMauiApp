using BlzMauiApp.Models;

namespace BlzMauiApp.Services.Data
{
    public interface ILoginDatabase
    {
        Task<List<UserInfo>> GetItemsAsync();
        Task<int> GetTotalCountAsync();
        Task<List<UserInfo>> GetItemsByIDAsync(string LocalLoginID);
        Task<List<UserInfo>> GetItemsByEmailAsync(string Username);
        Task<UserInfo> GetItemAsync(int id);
        Task<int> SaveItemAsync(UserInfo item);
        Task<int> DeleteItemAsync(UserInfo item);
        Task<int> TruncateTableAsync();
    }
}
