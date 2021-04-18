using System;
using System.Collections;
using System.Collections.Generic;
using Xamarin.Forms;

namespace BWFSamples.Models
{
    public sealed class ViewDefinitionModel
    {
        public Type Type { get; }
        public string Title { get; }
        public string Description { get; }
        public Color Color { get; }
        public IEnumerable<string> Platforms { get; }



        public ViewDefinitionModel(Type type, string title, string description, IEnumerable<string> platforms = null)
            : this(type, title, Color.Default, description, platforms)
        {
        }

        public ViewDefinitionModel(Type type, string title, Color color, string description, IEnumerable<string> platforms = null)
        {
            Type = type;
            Title = title;
            Description = description;
            Color = color;
            Platforms = platforms;
        }

    }
}
