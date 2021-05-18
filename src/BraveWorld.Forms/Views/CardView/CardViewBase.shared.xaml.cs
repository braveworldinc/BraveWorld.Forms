using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.CommunityToolkit;
using BraveWorld.Forms.Classes;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Xamarin.Forms.PancakeView;
using BraveWorld.Forms.Extensions;
using System.ComponentModel;

namespace BraveWorld.Forms.Views
{
    public partial class CardViewBase : ContentView
    {
        #region Properties
        public static readonly BindableProperty CardColorProperty = BindableProperty.Create(
            propertyName: nameof(CardColor),
            returnType: typeof(Color),
            declaringType: typeof(CardViewBase),
            defaultValue: null
        );

        public Color CardColor
        {
            get => (Color)GetValue(CardColorProperty);
            set => SetValue(CardColorProperty, value);
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


        public enum ECardStyle
        {
            Default,
            Colored
        }

        public static readonly BindableProperty CardStyleProperty = BindableProperty.Create(
            propertyName: nameof(CardStyle),
            returnType: typeof(ECardStyle),
            declaringType: typeof(CardViewBase),
            defaultValue: ECardStyle.Default
        );

        public ECardStyle CardStyle
        {
            get => (ECardStyle)GetValue(CardStyleProperty);
            set => SetValue(CardStyleProperty, value);
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

            if (propertyName == CardStyleProperty.PropertyName)
                SetStyle(CardStyle);

            //if (propertyName == CardBackgroundColorProperty.PropertyName)
            //    SetCardBackgroundColor(CardBackgroundColor);

            //if (propertyName == ShadowColorProperty.PropertyName)
            //    SetShadowColor(ShadowColor);
        }


        private void SetStyle(ECardStyle style)
        {
            switch (style)
            {
                case ECardStyle.Colored:
                    Color _color = CardColor;

                    CardFrame.BackgroundColor = _color.WithAlpha(0.7);
                    //Xamarin.CommunityToolkit.Effects.ShadowEffect.SetColor(CardFrame, SystemColors.Blue.LightColor);
                    RootPancake.Shadow = CreateShadow(_color, 0.3f);
                    break;
            }

            Console.WriteLine();
        }


        private void SetCardBackgroundColor(Color? color)
        {
            if (color != null)
            {
                //RootPancake.BackgroundColor = color.Value;
                CardFrame.BackgroundColor = color.Value;
                //RootPancake.BackgroundColor = color.Value;
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
                //RootPancake.Shadow = CreateShadow(color.Value.WithAlpha(1), 0.3f);
            } else
            {
                //RootPancake.Shadow = CreateShadow(Color.Black);
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
