using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.CommunityToolkit;
using BraveWorld.Forms.Classes;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Xamarin.Forms.PancakeView;
using BraveWorld.Forms.Extensions;

namespace BraveWorld.Forms.Views
{
    public partial class CardView : Grid
    {
        #region Properties
        public static readonly BindableProperty ForegroundColorProperty = BindableProperty.Create(
            propertyName: nameof(ForegroundColor),
            returnType: typeof(Color),
            declaringType: typeof(CardView),
            defaultValue: null
        );

        public Color ForegroundColor
        {
            get => (Color)GetValue(ForegroundColorProperty);
            set => SetValue(ForegroundColorProperty, value);
        }


        public static readonly BindableProperty TintColorProperty = BindableProperty.Create(
            propertyName: nameof(TintColor),
            returnType: typeof(Color),
            declaringType: typeof(CardView),
            defaultValue: null
        );

        public Color TintColor
        {
            get => (Color)GetValue(TintColorProperty);
            set => SetValue(TintColorProperty, value);
        }

        public static readonly BindableProperty CardBackgroundColorProperty = BindableProperty.Create(
            propertyName: nameof(CardBackgroundColor),
            returnType: typeof(Color?),
            declaringType: typeof(CardView),
            defaultValue: null
        );

        public Color? CardBackgroundColor
        {
            get => (Color?)GetValue(CardBackgroundColorProperty);
            set => SetValue(CardBackgroundColorProperty, value);
        }

        public static readonly BindableProperty ShadowColorProperty = BindableProperty.Create(
            propertyName: nameof(ShadowColor),
            returnType: typeof(Color?),
            declaringType: typeof(CardView),
            defaultValue: null
        );

        public Color? ShadowColor
        {
            get => (Color?)GetValue(ShadowColorProperty);
            set => SetValue(ShadowColorProperty, value);
        }



        public static readonly BindableProperty TitleProperty = BindableProperty.Create(
            propertyName: nameof(Title),
            returnType: typeof(string),
            declaringType: typeof(CardView)
        );

        public string Title
        {
            get => (string)GetValue(TitleProperty);
            set => SetValue(TitleProperty, value);
        }

        public static readonly BindableProperty HeadlineProperty = BindableProperty.Create(
            propertyName: nameof(Headline),
            returnType: typeof(string),
            declaringType: typeof(CardView)
        );

        public string Headline
        {
            get => (string)GetValue(HeadlineProperty);
            set => SetValue(HeadlineProperty, value);
        }

        public static readonly BindableProperty MessageProperty = BindableProperty.Create(
            propertyName: nameof(Message),
            returnType: typeof(string),
            declaringType: typeof(CardView)
        );

        public string Message
        {
            get => (string)GetValue(MessageProperty);
            set => SetValue(MessageProperty, value);
        }

        public static readonly BindableProperty CommandProperty = BindableProperty.Create(
            propertyName: nameof(Command),
            returnType: typeof(ICommand),
            declaringType: typeof(CardView)
        );

        public ICommand Command
        {
            get => (ICommand)GetValue(CommandProperty);
            set => SetValue(CommandProperty, value);
        }


        public static readonly BindableProperty BannerImageProperty = BindableProperty.Create(
            propertyName: nameof(BannerImage),
            returnType: typeof(ImageSource),
            declaringType: typeof(CardView),
            defaultValue: null
        );

        public ImageSource BannerImage
        {
            get => (ImageSource)GetValue(BannerImageProperty);
            set
            {
                SetValue(BannerImageProperty, value);
                ShowBannerImage(value != null);
            }
        }


        public static readonly BindableProperty IsBusyProperty = BindableProperty.Create(
            propertyName: nameof(IsBusy),
            returnType: typeof(bool),
            declaringType: typeof(CardView),
            defaultValue: false
        );

        public bool IsBusy
        {
            get => (bool)GetValue(IsBusyProperty);
            set => SetValue(IsBusyProperty, value);
        }


        #endregion

        public CardView()
        {
            InitializeComponent();
        }

        protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);

            if (propertyName == BannerImageProperty.PropertyName)
                SetBannerImage(BannerImage);

            if (propertyName == CardBackgroundColorProperty.PropertyName)
                SetCardBackgroundColor(CardBackgroundColor);
            
            
            //if(propertyName == BackgroundColorProperty.PropertyName || propertyName == ForegroundColorProperty.PropertyName || propertyName == CardBackgroundColorProperty.PropertyName)
            //    UpdateForegroundColor();


            //if (propertyName == ForegroundColorProperty.PropertyName)
            //    SetForegroundColor(ForegroundColor);

            //if (propertyName == ShadowColorProperty.PropertyName)
            //    SetShadowColor(ShadowColor);
        }


        private void SetLabelTextAndVisibility(Label label, string text)
        {
            bool _hasText = !string.IsNullOrEmpty(text);

            label.Text = text;
            label.HeightRequest = (_hasText) ? -1 : 0;
            label.IsVisible = _hasText;
        }

        private void SetCardBackgroundColor(Color? color)
        {
            if(color != null)
            {
                pancakeView.BackgroundColor = color.Value;
                cardFrame.BackgroundColor = color.Value;
            }

            SetShadowColor(color);
        }

        private void SetBannerImage(ImageSource source)
        {
            bool _hasImage = source != null;
            cardImage.Source = source;
            ShowBannerImage(_hasImage);
        }

        private void ShowBannerImage(bool isVisible)
        {
            cardImage.IsVisible = isVisible;
            cardImage.HeightRequest = isVisible ? 250 : 0;
            cardImage.Opacity = isVisible ? 1 : 0;
        }

        private void UpdateForegroundColor()
        {
            if(CardBackgroundColor != null)
            {
                Color _foregroundColor = CardBackgroundColor.Value.IsDarkColor() ? Color.White : Color.Black;

                //if (ShadowColor != null)
                //    _foregroundColor = pancakeView.BackgroundColor.IsDarkColor() ? Color.White : Color.Black;

                cardTitle.TextColor = _foregroundColor;
                cardHeadline.TextColor = _foregroundColor;
                cardMessage.TextColor = _foregroundColor;
            }
        }

        private void SetShadowColor(Color? color = null)
        {
            if(color != null)
            {
                pancakeView.Shadow = CreateShadow(color.Value.WithAlpha(1), 0.3f);
            } else
            {
                pancakeView.Shadow = CreateShadow(Color.Black);
            }
        }

        private DropShadow CreateShadow(Color color, float opacity = 0.1f)
        {
            //<yummy:DropShadow Color="#88000000" Offset="0,15" BlurRadius="15" Opacity="0.3"/>
            
            return new DropShadow()
            {
                Color = color,
                Offset = new Point(0, 15),
                BlurRadius = 15,
                Opacity = opacity
            };
        }

        //private void UpdateStyling()
        //{
        //    var style = CardStyle;
        //    ShowBannerImage(HasImage);
        //}
    }
}
