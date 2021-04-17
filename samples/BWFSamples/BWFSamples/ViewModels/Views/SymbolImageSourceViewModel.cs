using System;
using System.Collections.ObjectModel;
using BraveWorld.Forms.Classes;

namespace BWFSamples.ViewModels.Views
{
    public class SymbolImageSourceViewModel : BaseViewModel
    {
        public ObservableCollection<SymbolImageDefinition> Symbols => new ObservableCollection<SymbolImageDefinition>()
        {
            new SymbolImageDefinition("face.smiling"),
            new SymbolImageDefinition("square.and.arrow.up"),
            new SymbolImageDefinition("pencil"),
            new SymbolImageDefinition("trash.slash"),
            new SymbolImageDefinition("folder"),
            new SymbolImageDefinition("chart.bar.doc.horizontal"),
            new SymbolImageDefinition("powersleep")
        };

        public SymbolImageSourceViewModel()
        {

        }
    }


    public struct SymbolImageDefinition
    {
        public string Glyph { get; private set; }


        public SymbolImageDefinition(string glyph)
        {
            Glyph = glyph;
        }
    }
}
