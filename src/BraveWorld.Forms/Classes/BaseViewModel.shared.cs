using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace BraveWorld.Forms.Classes
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        #region Properties
        private bool _isBusy = false;
        public bool IsBusy
        {
            get => _isBusy;
            set => SetProperty(ref _isBusy, value);
        }

        private string _title = string.Empty;
        public string Title
        {
            get => _title;
            set => SetProperty(ref _title, value);
        }
        #endregion

        public BaseViewModel()
        {

        }

        #region INotifyPropertyChanged
        protected bool SetProperty<T>(ref T backingStore, T value,
            [CallerMemberName] string propertyName = "",
            Action onChanged = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
                return false;

            backingStore = value;
            onChanged?.Invoke();
            OnPropertyChanged(propertyName);
            return true;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            var changed = PropertyChanged;
            if (changed == null)
                return;

            changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion



        public async Task DisplayAlert(string title, string message, string cancel)
        {
            await Application.Current.MainPage.DisplayAlert(title, message, cancel);
        }

        public async Task DisplayAlert(string title, string message, string accept, string cancel = "Cancel")
        {
            await Application.Current.MainPage.DisplayAlert(title, message, accept, cancel);
        }

        public static async Task ShowException(Exception e)
        {
            await Application.Current.MainPage.DisplayAlert("Exception Thrown", e.Message, "Great...");
        }
    }

    public class BaseViewModel<TDataService> : INotifyPropertyChanged
        where TDataService : BaseDataService
    {
        protected TDataService DataService;

        #region Properties
        private bool _isBusy = false;
        public bool IsBusy
        {
            get => _isBusy;
            set
            {
                SetProperty(ref _isBusy, value);
                OnPropertyChanged(nameof(IsNotBusy));
            }
        }
        public bool IsNotBusy => !IsBusy;


        private string _title = string.Empty;
        public string Title
        {
            get => _title;
            set => SetProperty(ref _title, value);
        }
        #endregion

        public BaseViewModel()
        {
            DataService = DependencyService.Get<TDataService>();
        }


        #region INotifyPropertyChanged
        protected bool SetProperty<T>(ref T backingStore, T value,
            [CallerMemberName] string propertyName = "",
            Action onChanged = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
                return false;

            backingStore = value;
            onChanged?.Invoke();
            OnPropertyChanged(propertyName);
            return true;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            var changed = PropertyChanged;
            if (changed == null)
                return;

            changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion



        public async Task DisplayAlert(string title, string message, string cancel)
        {
            await Application.Current.MainPage.DisplayAlert(title, message, cancel);
        }

        public async Task DisplayAlert(string title, string message, string accept, string cancel = "Cancel")
        {
            await Application.Current.MainPage.DisplayAlert(title, message, accept, cancel);
        }

        public static async Task ShowException(Exception e)
        {
            await Application.Current.MainPage.DisplayAlert("Exception Thrown", e.Message, "Lovely");
        }

        public static async Task ShowException(DataServiceRequestException e)
        {
            await Application.Current.MainPage.DisplayAlert($"Exception Thrown: {e.StatusCode}", e.Message, "Lovely");
        }
    }
}
