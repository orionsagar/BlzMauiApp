using BlzMauiApp.Models;
using BlzMauiApp.Services.DataService;
using Microsoft.AspNetCore.Components;

namespace BlzMauiApp.Services
{
    public interface IAccountService
    {
        UserInfo User { get; }
        Task Initialize();
        Task Login(LoginViewModel model);
        Task Logout();
        Task Register(UserInfo model);
        Task<IList<UserInfo>> GetAll();
        Task<UserInfo> GetById(string id);
        Task Update(string id, UserInfo model);
        Task Delete(string id);
    }
    public class AccountService : IAccountService
    {
        //private IHttpService _httpService;
        private APIDataService _dataService;
        private NavigationManager _navigationManager;
        private ILocalStorageService _localStorageService;
        private string _userKey = "user";

        public AccountService(APIDataService dataService,
           NavigationManager navigationManager,
           ILocalStorageService localStorageService
       )
        {
            //_httpService = httpService;
            _dataService= dataService;
            _navigationManager = navigationManager;
            _localStorageService = localStorageService;
        }

        public UserInfo User { get; private set; }

        public Task Delete(string id)
        {
            throw new NotImplementedException();
        }

        public Task<IList<UserInfo>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<UserInfo> GetById(string id)
        {
            throw new NotImplementedException();
        }

        public async Task Initialize()
        {
            User = await _localStorageService.GetItem<UserInfo>(_userKey);
        }

        public async Task Login(LoginViewModel model)
        {
            //User = await _httpService.Post<UserInfo>("/users/authenticate", model);
            User = await _dataService.GetUserInfoAsync(model);
            await _localStorageService.SetItem(_userKey, User);
        }

        public Task Logout()
        {
            throw new NotImplementedException();
        }

        public Task Register(UserInfo model)
        {
            throw new NotImplementedException();
        }

        public Task Update(string id, UserInfo model)
        {
            throw new NotImplementedException();
        }
    }
}
