using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace BraveWorld.Forms.Classes
{
    public interface IAppThemeResource
    {
        object Light { get; }
        object Dark { get; }
        object Default { get; }
    }

    public class AppThemeResource<T> : IAppThemeResource
    {
        public T Light { get; set; }
        public T Dark { get; set; }
        public T Default { get; set; }
        object IAppThemeResource.Light => Light;
        object IAppThemeResource.Dark => Dark;
        object IAppThemeResource.Default => Default;
    }

    public class AppThemeColor : AppThemeResource<Color>
    {
    }

    public class AppThemeResources : IReadOnlyDictionary<OSAppTheme, ResourceDictionary>
    {
        private readonly Dictionary<OSAppTheme, ResourceDictionary> _themedResources;
        private readonly ICollection<ResourceDictionary> _mergedDictionaries;
        public AppThemeResources(Application application)
        {
            _themedResources = new Dictionary<OSAppTheme, ResourceDictionary>
            {
                { OSAppTheme.Unspecified, new ResourceDictionary() },
                { OSAppTheme.Light, new ResourceDictionary() },
                { OSAppTheme.Dark, new ResourceDictionary() },
            };
            ResourceDictionary resources = application.Resources;
            _mergedDictionaries = resources.MergedDictionaries;
            var appThemeResources = resources.Where(kvp => kvp.Value is IAppThemeResource).ToList();
            foreach (var kvp in appThemeResources)
            {
                var key = kvp.Key;
                var tr = (IAppThemeResource)kvp.Value;
                _themedResources[OSAppTheme.Unspecified][key] = tr.Default;
                _themedResources[OSAppTheme.Light][key] = tr.Default; // custom: should be tr.Light
                _themedResources[OSAppTheme.Dark][key] = tr.Dark;
                resources.Remove(key);
            }
            application.RequestedThemeChanged += (s, a) =>
            {
                foreach (var d in _themedResources.Values)
                {
                    _mergedDictionaries.Remove(d);
                }
                _mergedDictionaries.Add(_themedResources[a.RequestedTheme]);
            };
            _mergedDictionaries.Add(_themedResources[application.RequestedTheme]);
        }

        #region "IReadOnlyDictionary"
        public ResourceDictionary this[OSAppTheme key] =>
            ((IReadOnlyDictionary<OSAppTheme, ResourceDictionary>)_themedResources)[key];

        public IEnumerable<OSAppTheme> Keys =>
            ((IReadOnlyDictionary<OSAppTheme, ResourceDictionary>)_themedResources).Keys;

        public IEnumerable<ResourceDictionary> Values =>
            ((IReadOnlyDictionary<OSAppTheme, ResourceDictionary>)_themedResources).Values;

        public int Count => ((IReadOnlyCollection<KeyValuePair<OSAppTheme, ResourceDictionary>>)_themedResources).Count;

        public bool ContainsKey(OSAppTheme key) =>
            ((IReadOnlyDictionary<OSAppTheme, ResourceDictionary>)_themedResources).ContainsKey(key);
        public IEnumerator<KeyValuePair<OSAppTheme, ResourceDictionary>> GetEnumerator() =>
            ((IEnumerable<KeyValuePair<OSAppTheme, ResourceDictionary>>)_themedResources).GetEnumerator();
        public bool TryGetValue(OSAppTheme key, out ResourceDictionary value) =>
            ((IReadOnlyDictionary<OSAppTheme, ResourceDictionary>)_themedResources).TryGetValue(key, out value);
        IEnumerator IEnumerable.GetEnumerator() => ((IEnumerable)_themedResources).GetEnumerator();
        #endregion
    }
}
