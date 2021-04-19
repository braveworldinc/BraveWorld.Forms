using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
        public Func<ViewDefinitionModel, bool> IsVisibleWithConditions { get; }


        public ViewDefinitionModel(Type type, string title, string description, Func<ViewDefinitionModel, bool> conditions = null, IEnumerable<string> platforms = null)
        {
            Type = type;
            Title = title;
            Description = description;
            Platforms = platforms;
            IsVisibleWithConditions = conditions;
        }

    }
}
