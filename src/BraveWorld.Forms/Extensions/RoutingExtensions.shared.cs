using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace BraveWorld.Forms.Extensions
{
    public static class RoutingExtensions
    {
        public static void RegisterRoute(string name, Type type)
        {
            Console.WriteLine($"Registered Route: {name} typeof {type.Name}");
            Routing.RegisterRoute(name, type);
        }

        public static void RegisterRoute<TPage>() where TPage : Page => RegisterRoute(typeof(TPage).Name, typeof(TPage));
        public static void RegisterRoute<TPage>(string path) where TPage : Page => RegisterRoute(path, typeof(TPage));

        public static void RegisterRoute<TMasterPage, TDetailPage>()
            where TMasterPage : Page
            where TDetailPage : Page
        {
            RegisterRoute<TMasterPage>();
            RegisterRoute<TDetailPage>();
        }
        public static void RegisterRoute<TMasterPage, TDetailPage>(string masterPath, string detailPath = null)
            where TMasterPage : Page
            where TDetailPage : Page
        {
            RegisterRoute<TMasterPage>(masterPath);

            var _detailsPath = (!string.IsNullOrEmpty(detailPath)) ? detailPath : $"{masterPath}/details";
            RegisterRoute<TDetailPage>(_detailsPath);
        }


        public static string GenerateQuery(string path, string query = null)
        {
            string returnValue = path;

            if (!string.IsNullOrWhiteSpace(query))
                returnValue = $"{path}?{query}";

            return returnValue;
        }

        public static string GenerateQuery<TPage>(string query = null) where TPage : Page
        {
            string generatedName = typeof(TPage).Name;

            if (string.IsNullOrWhiteSpace(query))
                return generatedName;
            else
                return $"{generatedName}?{query}";
        }

        public static async Task GoToAsync(string path, string query = null)
        {
            await Shell.Current.GoToAsync(GenerateQuery(path, query), true);
        }
        public static async Task GoToAsync<TPage>(string query = null) where TPage : Page
        {
            await Shell.Current.GoToAsync(GenerateQuery<TPage>(query), true);
        }


        public static async Task GoToDetailPage<TPage>(TPage detailPage, string query = null) where TPage : Page
        {
            await Application.Current.MainPage.Navigation.PushAsync(detailPage);
        }
        public static async Task GoToDetailPage(string masterPath, string query = null)
        {
            string _path = GenerateQuery($"{masterPath}/details", query);
            await Shell.Current.GoToAsync(_path, true);
        }



        public static async Task GoBackAsync() => await Shell.Current.GoToAsync("..", true);
        public static async Task PopAsync() => await Shell.Current.Navigation.PopAsync(true);


        public static async Task ShowOnboardingAsync() => await GoToAsync("//startup");
        public static async Task ShowLoginAsync() => await GoToAsync("//login");
        public static async Task ShowMainAsync() => await GoToAsync("//main");
    }
}
