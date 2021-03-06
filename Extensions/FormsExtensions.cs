using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace BraveWorld.Forms.Extensions
{
    public static class FormsExtensions
    {

        public static async Task ShowExceptionAlert(this Page sender, Exception e)
        {
            await sender.DisplayAlert("Exception Thrown", e.Message, "Great...");
        }
    }
}
