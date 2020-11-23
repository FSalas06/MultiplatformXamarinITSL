using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Acr.UserDialogs;
using Xamarin.Forms;

namespace agenda_its.ViewModels
{
    public class BaseViewmodel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public virtual void OnAppearing()
        {
            Debug.WriteLine("OnAppearing()");
        }

        public void GoToNextPage(Page page)
        {
            App.GlobalNavigation.PushAsync(page);
        }

        public void AlertToast(string message)
        {
            ToastConfig toast = new ToastConfig(message);
            UserDialogs.Instance.Toast(toast);
        }
    }
}
