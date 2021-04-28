using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.CommunityToolkit;
using BraveWorld.Forms.Classes;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace BraveWorld.Forms.Views
{
    public partial class CardView : Frame
    {
        #region Properties
        public static readonly BindableProperty TextColorProperty = BindableProperty.Create(
            propertyName: nameof(TextColor),
            returnType: typeof(Color?),
            declaringType: typeof(CardView),
            defaultValue: null
        );

        public Color? TextColor
        {
            get => (Color?)GetValue(TextColorProperty);
            set => SetValue(TextColorProperty, value);
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
        #endregion

        public CardView()
        {
            InitializeComponent();
        }

        protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);


            //if(propertyName == TextColorProperty.PropertyName)
            //{
            //    if(TextColor != null)
            //    {
            //        titleLabel.TextColor = TextColor ?? Color.Default;
            //        headlineLabel.TextColor = TextColor ?? Color.Default;
            //        messageLabel.TextColor = TextColor ?? Color.Default;
            //    }
            //}

            if (propertyName == TitleProperty.PropertyName)
                titleLabel.Text = Title;

            if (propertyName == HeadlineProperty.PropertyName)
                headlineLabel.Text = Headline;

            if (propertyName == MessageProperty.PropertyName)
                messageLabel.Text = Message;
        }
    }
}
