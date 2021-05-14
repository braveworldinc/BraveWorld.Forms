using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.CommunityToolkit;
using BraveWorld.Forms.Classes;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Xamarin.Forms.PancakeView;

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


        //public enum ECardStyle
        //{
        //    Default,
        //    Image
        //}

        //public static readonly BindableProperty CardStyleProperty = BindableProperty.Create(
        //    propertyName: nameof(CardStyle),
        //    returnType: typeof(ECardStyle),
        //    declaringType: typeof(CardView),
        //    defaultValue: ECardStyle.Default
        //);

        //public ECardStyle CardStyle
        //{
        //    get => (ECardStyle)GetValue(CardStyleProperty);
        //    set => SetValue(CardStyleProperty, value);
        //}


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

            if (propertyName == ForegroundColorProperty.PropertyName)
                UpdateForegroundColor(ForegroundColor);


            //if (propertyName == TitleProperty.PropertyName)
            //    SetLabelTextAndVisibility(cardTitle, Title);

            //if (propertyName == HeadlineProperty.PropertyName)
            //    SetLabelTextAndVisibility(cardHeadline, Headline);

            //if (propertyName == MessageProperty.PropertyName)
            //    SetLabelTextAndVisibility(cardMessage, Message);
        }


        private void SetLabelTextAndVisibility(Label label, string text)
        {
            bool _hasText = !string.IsNullOrEmpty(text);

            label.Text = text;
            label.HeightRequest = (_hasText) ? -1 : 0;
            label.IsVisible = _hasText;
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

        private void UpdateForegroundColor(Color? color = null)
        {
            var _foregroundColor = color ?? ForegroundColor;
            cardTitle.TextColor = _foregroundColor;
            cardHeadline.TextColor = _foregroundColor;
            cardMessage.TextColor = _foregroundColor;
        }

        //private void UpdateStyling()
        //{
        //    var style = CardStyle;
        //    ShowBannerImage(HasImage);
        //}
    }
}
