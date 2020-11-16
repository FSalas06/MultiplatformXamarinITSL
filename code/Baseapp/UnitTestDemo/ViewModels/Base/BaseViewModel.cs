using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using UnitTestDemo.Contracts.Services.General;

namespace UnitTestDemo.ViewModels.Base
{
    /// <summary>
    /// Base view model
    /// </summary>
    public class BaseViewModel : INotifyPropertyChanged
    {
        #region Properties
        
        private bool _isBusy;
                
        public bool IsBusy
        {
            get => _isBusy;
            set
            {
                _isBusy = value;
                OnPropertyChanged(nameof(IsBusy));
            }
        }

        protected readonly IConnectivityService _connectivityService;

        protected readonly INavigationService _navigationService;

        protected readonly IDialogService _dialogService;

        #endregion Properties

        #region Constructors
                
        public BaseViewModel(IConnectivityService connectionService, INavigationService navigationService, IDialogService dialogService)
        {
            _connectivityService = connectionService;
            _navigationService = navigationService;
            _dialogService = dialogService;
        }

        #endregion Constructors

        #region Property notification
                
        public event PropertyChangedEventHandler PropertyChanged;
                
        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        
        public virtual Task InitializeAsync(object data)
        {
            return Task.FromResult(false);
        }

        #endregion Property notification
    }
}
