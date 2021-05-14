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
    public partial class CardViewBase : ContentView
    {
        #region Properties


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
            returnType: typeof(Color),
            declaringType: typeof(CardViewBase),
            defaultValue: null
        );

        public Color CardBackgroundColor
        {
            get => (Color)GetValue(CardBackgroundColorProperty);
            set => SetValue(CardBackgroundColorProperty, value);
        }

        public static readonly BindableProperty ShadowColorProperty = BindableProperty.Create(
            propertyName: nameof(ShadowColor),
            returnType: typeof(Color),
            declaringType: typeof(CardViewBase),
            defaultValue: null
        );

        public Color ShadowColor
        {
            get => (Color)GetValue(ShadowColorProperty);
            set => SetValue(ShadowColorProperty, value);
        }


        public static readonly BindableProperty CommandProperty = BindableProperty.Create(
            propertyName: nameof(Command),
            returnType: typeof(ICommand),
            declaringType: typeof(CardViewBase)
        );

        public ICommand Command
        {
            get => (ICommand)GetValue(CommandProperty);
            set => SetValue(CommandProperty, value);
        }

        public static readonly BindableProperty IsBusyProperty = BindableProperty.Create(
            propertyName: nameof(IsBusy),
            returnType: typeof(bool),
            declaringType: typeof(CardViewBase),
            defaultValue: false
        );

        public bool IsBusy
        {
            get => (bool)GetValue(IsBusyProperty);
            set => SetValue(IsBusyProperty, value);
        }


        #endregion


        private PancakeView _rootPancake;
        protected PancakeView RootPancake
        {
            get
            {
                if (_rootPancake == null)
                    _rootPancake = (PancakeView)GetTemplateChild("pancakeView");

                return _rootPancake;
            }
        }


        private Frame _cardFrame;
        protected Frame CardFrame
        {
            get
            {
                if (_cardFrame == null)
                    _cardFrame = (Frame)GetTemplateChild("cardFrame");

                return _cardFrame;
            }
        }


        public CardViewBase()
        {
            InitializeComponent();
        }


        protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);

            if (propertyName == CardBackgroundColorProperty.PropertyName)
                SetCardBackgroundColor(CardBackgroundColor);

            if (propertyName == ShadowColorProperty.PropertyName)
                SetShadowColor(ShadowColor);
        }


        private void SetCardBackgroundColor(Color? color)
        {
            if (color != null)
            {
                RootPancake.BackgroundColor = color.Value;
                CardFrame.BackgroundColor = color.Value;

                //pancakeView.BackgroundColor = color.Value;
                //cardFrame.BackgroundColor = color.Value;
            }
            else
            {

            }

            //SetShadowColor(color);
        }

        private void SetShadowColor(Color? color = null)
        {
            if(color != null)
            {
                RootPancake.Shadow = CreateShadow(color.Value.WithAlpha(1), 0.3f);
            } else
            {
                RootPancake.Shadow = CreateShadow(Color.Black);
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
    }
}
