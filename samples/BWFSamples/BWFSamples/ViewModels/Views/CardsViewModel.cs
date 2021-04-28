using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using BraveWorld.Forms.Classes;
using System.Collections.ObjectModel;

namespace BWFSamples.ViewModels.Views
{
    public class CardsViewModel : BaseViewModel
    {
        public ObservableCollection<CardDefinition> Cards => new ObservableCollection<CardDefinition>()
        {
            new CardDefinition
            {
                Title = "This is a card",
                Headline = "Headline",
                Message = "Message goes here",
                BackgroundColor = Color.FromHex("$007aff")
            },
            new CardDefinition
            {
                Title = "What to Watch This Week",
                Headline = "Now Trending",
                Message = "Stream new Handmaid's Tale, Without Remorse, and the Falcon finale.",
                Image = ImageSource.FromResource("BWFSamples.Resources.Images.adult-3086304_1920.jpg"),
                CardTapCommand = new Command(() => {
                    Console.WriteLine("Card Tapped!");
                })
            },
            new CardDefinition
            {
                Title = "Man, look at this landscape!",
                Headline = "Now Trending",
                Message = "Stream new Handmaid's Tale, Without Remorse, and the Falcon finale.",
                Image = ImageSource.FromResource("BWFSamples.Resources.Images.pexels-photo-1323550.jpeg"),
                CardTapCommand = new Command(() => {
                    Console.WriteLine("Card Tapped!");
                })
            },
            new CardDefinition
            {
                Title = "This is a card",
                Headline = "Headline",
                Message = "Message goes here"
            },
        };

        public ICommand CardTapCommand { get; }

        public CardsViewModel()
        {
            CardTapCommand = new Command(() => {
                Console.WriteLine("Card Tapped!");
            });
        }
    }

    public struct CardDefinition
    {
        public string Title { get; set; }
        public string Headline { get; set; }
        public string Message { get; set; }
        public ImageSource Image { get; set; }
        public Color? TextColor { get; set; }
        public Color? BackgroundColor { get; set; }
        public ICommand CardTapCommand { get; set; }

        public bool HasImage => Image != null;
    }
}
