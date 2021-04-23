using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using BraveWorld.Forms;
using BraveWorld.Forms.Classes;
using BWFSamples.Models;

namespace BWFSamples.ViewModels.Views
{
    public class ColorsViewModel : BaseViewModel
    {
        private ObservableCollection<SystemColor> _colors;
        public ObservableCollection<SystemColor> Colors
        {
            get => _colors;
            set => SetProperty(ref _colors, value);
        }

        public ColorsViewModel()
        {
            Title = "Colors";

            Colors = new ObservableCollection<SystemColor>(SystemColors.AsNumerable());
        }
    }
}
