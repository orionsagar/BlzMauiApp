using BlzMauiApp.Models;
using Blazorise;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlzMauiApp.Services
{
    public interface IAlertService
    {
        event Action<Alerts> OnAlert;
        void Success(string message, bool keepAfterRouteChange = false, bool autoClose = true);
        void Error(string message, bool keepAfterRouteChange = false, bool autoClose = true);
        void Info(string message, bool keepAfterRouteChange = false, bool autoClose = true);
        void Warn(string message, bool keepAfterRouteChange = false, bool autoClose = true);
        void Alerts(Alerts alert);
        void Clear(string id = null);
    }
    public class AlertService : IAlertService
    {
        private const string _defaultId = "alert custom-alert-1 alert-primary alert-dismissible fade show";
        public event Action<Alerts> OnAlert;

        public void Success(string message, bool keepAfterRouteChange = false, bool autoClose = true)
        {
            this.Alerts(new Alerts
            {
                Type = AlertType.Success,
                Message = message,
                KeepAfterRouteChange = keepAfterRouteChange,
                AutoClose = autoClose
            });
        }

        public void Error(string message, bool keepAfterRouteChange = false, bool autoClose = true)
        {
            this.Alerts(new Alerts
            {
                Type = AlertType.Error,
                Message = message,
                KeepAfterRouteChange = keepAfterRouteChange,
                AutoClose = autoClose
            });
        }

        public void Info(string message, bool keepAfterRouteChange = false, bool autoClose = true)
        {
            this.Alerts(new Alerts
            {
                Type = AlertType.Info,
                Message = message,
                KeepAfterRouteChange = keepAfterRouteChange,
                AutoClose = autoClose
            });
        }

        public void Warn(string message, bool keepAfterRouteChange = false, bool autoClose = true)
        {
            this.Alerts(new Alerts    
            {
                Type = AlertType.Warning,
                Message = message,
                KeepAfterRouteChange = keepAfterRouteChange,
                AutoClose = autoClose
            });
        }

        public void Alerts(Alerts alert)
        {
            alert.Id = alert.Id ?? _defaultId;
            this.OnAlert?.Invoke(alert);
        }

        public void Clear(string id = _defaultId)
        {
            this.OnAlert?.Invoke(new Alerts { Id = id });
        }
    }
}
