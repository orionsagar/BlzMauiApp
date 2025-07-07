using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlzMauiApp.Services
{
    interface IDialogService
    {
        Task<bool> DisplayConfirm(string title, string message, string accept, string cancel);
        
    }
    public class CDialogService : IDialogService
    {
        public async Task<bool> DisplayConfirm(string title, string message, string accept, string cancel)
        {
            return await Application.Current.MainPage.DisplayAlert(title, message, accept, cancel);
        }

    }
}
