using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using BraveWorld.Forms.Classes;
using System.Collections.ObjectModel;
using BraveWorld.Forms;
using BraveWorld.Forms.Extensions;
using ECardStyle = BraveWorld.Forms.Views.CardViewBase.ECardStyle;

namespace BWFSamples.ViewModels.Views
{
    public class CardsViewModel : BaseViewModel
    {
        public ObservableCollection<CardDefinition> Cards => new ObservableCollection<CardDefinition>()
        {
            new CardDefinition
            {
                Title = "This is a Card!",
                Headline = "More than a button",
                Message = "Provides a base content view styled and ready to go."
            },
            new CardDefinition
            {
                Title = "This is Blue",
                Headline = $"Hex: {SystemColors.Blue.LightColor.ToHexString()}",
                Message = "Sometimes you just need something colored for more emphasis.",
                CardStyle = ECardStyle.Colored,
                CardColor = SystemColors.Blue.LightColor
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
            }
        };


        public CardsViewModel()
        {

        }
    }

    public class CardDefinition
    {
        public string Title { get; set; } = string.Empty;
        public string Headline { get; set; } = string.Empty;
        public string Message { get; set; } = string.Empty;
        public ImageSource Image { get; set; } = null;
        public ECardStyle CardStyle { get; set; } = ECardStyle.Default;
        public Color? CardColor { get; set; } = null;
        public ICommand CardTapCommand { get; set; } = null;
    }
}
