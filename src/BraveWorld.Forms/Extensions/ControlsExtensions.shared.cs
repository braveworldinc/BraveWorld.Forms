using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace BraveWorld.Forms.Extensions
{
    public static class ControlsExtensions
    {

        public static void SetEnabled(this Button button, bool isEnabled, string? text)
        {
            if (isEnabled != button.IsEnabled)
            {
                button.IsEnabled = isEnabled;
                button.IsVisible = isEnabled;
            }


            button.Text = text ?? button.Text;
        }



        public static void GoToNext(this CarouselView carousel)
        {
            ICollection ts = (ICollection)carousel.ItemsSource;

            if ((carousel.Position + 1) < ts.Count && ts.Count > 0)
                carousel.Position++;
        }
        public static void GoToPrevious(this CarouselView carousel)
        {
            ICollection ts = (ICollection)carousel.ItemsSource;

            if ((carousel.Position - 1) >= 0 && ts.Count > 0)
                carousel.Position--;
        }

        public static string GetTotalAsSteps(this CarouselView carousel)
        {
            int currentStep = carousel.Position + 1;
            int totalSteps = (carousel.ItemsSource as ICollection).Count;

            return $"Step {currentStep}/{totalSteps}";
        }
    }
}
