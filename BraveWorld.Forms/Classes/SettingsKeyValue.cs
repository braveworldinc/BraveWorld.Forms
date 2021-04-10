using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace BraveWorld.Forms.Classes
{
    public class SettingsKeyValue : INotifyPropertyChanged
    {
        public string Key { get;}
        public string DefaultValue { get; }

        public string EventName => $"{Key}Changed";

        public delegate void ChangedEventHandler(string value);
        public event ChangedEventHandler OnValueChanged;
        public event PropertyChangedEventHandler PropertyChanged;


        public string Value
        {
            get => Preferences.Get(Key, DefaultValue);
            set
            {
                if (Value != value)
                {
                    Preferences.Set(Key, value);
                    OnValueChanged?.Invoke(value);
                    MessagingCenter.Send(Application.Current, "Meh", value);
                }
            }
        }




        public SettingsKeyValue(string key, string defaultValue = null)
        {
            Key = key;
            DefaultValue = defaultValue;
        }


        public string GetValue() => Value;

        public bool HasValue() => !string.IsNullOrEmpty(Value) && !string.IsNullOrWhiteSpace(Value);

        public void SetValue(string value) => SetValue(Application.Current, value);

        public void SetValue(object sender, string value)
        {
            if (Value != value)
            {
                Preferences.Set(Key, value);
                OnValueChanged?.Invoke(value);
                MessagingCenter.Send(sender, EventName, value);
            }
        }


        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        public void Subscribe(object subscriber, Action<string> callback) => MessagingCenter.Subscribe(subscriber, "Meh", callback);

        public void Unsubscribe(object subscriber) => MessagingCenter.Unsubscribe<string>(subscriber, "Meh");
    }
}
