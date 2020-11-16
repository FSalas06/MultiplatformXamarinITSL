using System.Windows.Input;
using UnitTestDemo.Contracts.Services;
using UnitTestDemo.Contracts.Services.General;
using UnitTestDemo.Models;
using UnitTestDemo.ViewModels.Base;
using Xamarin.Forms;

namespace UnitTestDemo.ViewModels
{
    public class ContactViewModel : BaseViewModel
    {
        public ICommand SubmitMessageCommand => new Command(OnSubmitMessage);
        public ICommand CallPhone => new Command(OnCallPhone);

        public string Message
        {
            get => _message;
            set
            {
                _message = value;
                OnPropertyChanged();
            }
        }

        public string Email
        {
            get => _email;
            set
            {
                _email = value;
                OnPropertyChanged();
            }
        }

        private readonly IContactDataService _contactDataService;

        private readonly IPhoneDialerService _phoneService;

        private string _email;

        private string _message;

        public ContactViewModel(IConnectivityService connectivityService, INavigationService navigationService, IDialogService dialogService, IContactDataService contactDataService, IPhoneDialerService phoneService) : base(connectivityService, navigationService, dialogService)
        {
            _contactDataService = contactDataService;
            _phoneService = phoneService;
        }         

        private async void OnSubmitMessage()
        {
            await _contactDataService.AddContactInfoAsync(new ContactInfo { Message = Message, Email = Email });
            await _dialogService.ShowDialog("Thank you for your comment", "Thank you", "OK");
        }

        private void OnCallPhone()
        {
            _phoneService.PlacePhoneCall("5554885002");
        }
    }
}
