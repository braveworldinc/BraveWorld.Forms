using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using BraveWorld.Forms.Classes;

namespace BWFSamples.ViewModels.Views
{
    public class SymbolImageSourceViewModel : BaseViewModel
    {
        public ObservableCollection<SymbolImageDefinition> Symbols { get; private set; }

        public SymbolImageSourceViewModel()
        {
            Symbols = new ObservableCollection<SymbolImageDefinition>(GetSymbols());
        }


        private IEnumerable<SymbolImageDefinition> GetSymbols()
        {
            IEnumerable<SymbolImageDefinition> symbols = new[]
            {
                new SymbolImageDefinition("face.smiling"),
                new SymbolImageDefinition("square.and.arrow.up"),
                new SymbolImageDefinition("pencil"),
                new SymbolImageDefinition("trash.slash"),
                new SymbolImageDefinition("folder"),
                new SymbolImageDefinition("chart.bar.doc.horizontal"),
                new SymbolImageDefinition("powersleep")
            };
            
            return symbols.OrderBy(s => s.Glyph);
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
