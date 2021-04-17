using System;
using Xamarin.Forms;

namespace BWFSamples.Models
{
    public sealed class ViewDefinitionModel
    {
        public Type Type { get; }
        public string Title { get; }
        public string Description { get; }
        public Color Color { get; }



        public ViewDefinitionModel(Type type, string title, string description)
            : this(type, title, Color.Default, description)
        {
        }

        public ViewDefinitionModel(Type type, string title, Color color, string description)
        {
            Type = type;
            Title = title;
            Description = description;
            Color = color;
        }

    }
}
