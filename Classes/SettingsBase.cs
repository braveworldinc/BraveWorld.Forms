using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace BraveWorld.Forms.Classes
{
    public class SettingsBase
    {





        public static string GenerateEventName(string propertyName) => $"{propertyName}Changed";

        public static void Set(string key, string value)
        {
            string oldValue = Preferences.Get(key, null);

            if (oldValue != value && !string.IsNullOrEmpty(value))
            {
                string eventName = GenerateEventName(key);
                Preferences.Set(key, value);
                MessagingCenter.Send(new object(), eventName, key);
            }
        }

        public static void Set<TSender>(TSender sender, string key, string value, bool showAlert = false) where TSender : Page
        {
            string oldValue = Preferences.Get(key, null);

            if (oldValue != value && !string.IsNullOrEmpty(value))
            {
                string eventName = GenerateEventName(key);

                Preferences.Set(key, value);
                MessagingCenter.Send(sender, eventName, key);

                if (showAlert)
                    sender.DisplayAlert($"{key} Updated", $"Value: {value}", "Okay");
            }
        }


        public static string Get(string key, string defaultValue = "") => Preferences.Get(key, defaultValue);
    }
}
