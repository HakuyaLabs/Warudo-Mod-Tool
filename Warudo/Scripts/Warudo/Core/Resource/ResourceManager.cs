using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using UMod;
using UnityEngine;
using Warudo.Core.Data;
using Warudo.Core.Localization;
using Warudo.Core.Plugins;
using Warudo.Core.Utils;

namespace Warudo.Core.Resource {
    public class ResourceManager {

        private readonly Dictionary<string, List<IResourceProvider>> providers = new();
        private readonly Dictionary<string, List<IResourceUriResolver>> uriResolvers = new();
        private readonly Dictionary<string, List<IResourceUriMetaResolver>> uriMetaResolvers = new();
        private readonly Dictionary<string, List<IResourceUriThumbnailResolver>> uriThumbnailResolvers = new();

        public void RegisterProvider(IResourceProvider provider, Plugin plugin) {
            if (!providers.ContainsKey(plugin.Type.PluginType.id)) {
                providers[plugin.Type.PluginType.id] = new();
            }
            providers[plugin.Type.PluginType.id].Add(provider ?? throw new ArgumentNullException(nameof(provider)));
        }

        public void RegisterUriResolver(IResourceUriResolver resolver, Plugin plugin) {
            if (!uriResolvers.ContainsKey(plugin.Type.PluginType.id)) {
                uriResolvers[plugin.Type.PluginType.id] = new();
            }
            uriResolvers[plugin.Type.PluginType.id].Add(resolver ?? throw new ArgumentNullException(nameof(resolver)));
        }
        
        public void RegisterUriMetaResolver(IResourceUriMetaResolver resolver, Plugin plugin) {
            if (!uriMetaResolvers.ContainsKey(plugin.Type.PluginType.id)) {
                uriMetaResolvers[plugin.Type.PluginType.id] = new();
            }
            uriMetaResolvers[plugin.Type.PluginType.id].Add(resolver ?? throw new ArgumentNullException(nameof(resolver)));
        }
        
        public void RegisterUriThumbnailResolver(IResourceUriThumbnailResolver resolver, Plugin plugin) {
            if (!uriThumbnailResolvers.ContainsKey(plugin.Type.PluginType.id)) {
                uriThumbnailResolvers[plugin.Type.PluginType.id] = new();
            }
            uriThumbnailResolvers[plugin.Type.PluginType.id].Add(resolver ?? throw new ArgumentNullException(nameof(resolver)));
        }

        public void UnregisterProvider(IResourceProvider provider, Plugin plugin) {
            if (!providers.ContainsKey(plugin.Type.PluginType.id)) {
                return;
            }
            providers[plugin.Type.PluginType.id].Remove(provider ?? throw new ArgumentNullException(nameof(provider)));
        }

        public void UnregisterUriResolver(IResourceUriResolver resolver, Plugin plugin) {
            if (!uriResolvers.ContainsKey(plugin.Type.PluginType.id)) {
                return;
            }
            uriResolvers[plugin.Type.PluginType.id].Remove(resolver ?? throw new ArgumentNullException(nameof(resolver)));
        }
        
        public void UnregisterMetaResolver(IResourceUriMetaResolver resolver, Plugin plugin) {
            if (!uriMetaResolvers.ContainsKey(plugin.Type.PluginType.id)) {
                return;
            }
            uriMetaResolvers[plugin.Type.PluginType.id].Remove(resolver ?? throw new ArgumentNullException(nameof(resolver)));
        }
        
        public void UnregisterUriThumbnailResolver(IResourceUriThumbnailResolver resolver, Plugin plugin) {
            if (!uriThumbnailResolvers.ContainsKey(plugin.Type.PluginType.id)) {
                return;
            }
            uriThumbnailResolvers[plugin.Type.PluginType.id].Remove(resolver ?? throw new ArgumentNullException(nameof(resolver)));
        }
        
        public void UnregisterAllProviders(Plugin plugin) {
            if (!providers.ContainsKey(plugin.Type.PluginType.id)) {
                return;
            }
            providers.Remove(plugin.Type.PluginType.id);
        }
        
        public void UnregisterAllUriResolvers(Plugin plugin) {
            if (!uriResolvers.ContainsKey(plugin.Type.PluginType.id)) {
                return;
            }
            uriResolvers.Remove(plugin.Type.PluginType.id);
        }
        
        public void UnregisterAllUriMetaResolvers(Plugin plugin) {
            if (!uriMetaResolvers.ContainsKey(plugin.Type.PluginType.id)) {
                return;
            }
            uriMetaResolvers.Remove(plugin.Type.PluginType.id);
        }
        
        public void UnregisterAllUriThumbnailResolvers(Plugin plugin) {
            if (!uriThumbnailResolvers.ContainsKey(plugin.Type.PluginType.id)) {
                return;
            }
            uriThumbnailResolvers.Remove(plugin.Type.PluginType.id);
        }

        private readonly Dictionary<string, (List<ResourceProviderResult> results, float expiryTime)> cachedResources = new();
        
        public List<ResourceProviderResult> ProvideResources(string query) {
            if (cachedResources.TryGetValue(query, out var kv)) {
                var (cachedResults, expiryTime) = kv;
                if (Time.time < expiryTime) {
                    return cachedResults;
                }
                // Remove expired cache
                cachedResources.Remove(query);
            }
            
            var results = providers.SelectMany(it => it.Value).Select(it =>
                {
                    var resources = it.ProvideResources(query);
                    if (resources == null || resources.Count == 0) {
                        return null;
                    }
                    return new ResourceProviderResult {
                        providerName = it.ResourceProviderName,
                        resources = it.ProvideResources(query)
                    };
                })
                .Where(it => it != null)
                .ToList();

            cachedResources[query] = (results, Time.time + 1f);
            return results;
        }
        
        public object ResolveResourceUri(Uri uri) {
            foreach (var resolver in uriResolvers.SelectMany(it => it.Value)) {
                try {
                    var result = resolver.Resolve(uri);
                    if (result != null) {
                        return result;
                    }
                } catch (Exception e) {
                    Log.Error($"An error occured when trying to resolve resource URI {uri}", e);
                    throw;
                }
            } 
            Log.UserError("Failed to resolve resource URI " + uri);
            return default;
        }

        public T ResolveResourceUri<T>(Uri uri) {
            var result = ResolveResourceUri(uri);
            if (result == null) return default;
            try {
                return (T)result;
            } catch (InvalidCastException e) {
                Log.Error($"Could not cast value resolved from resource URI {uri} of type {result.GetType().Name} as type {typeof(T).Name}", e);
                throw;
            }
        }
        
        public object ResolveResourceUri(string uri) {
            return ResolveResourceUri(new Uri(uri));
        }

        public T ResolveResourceUri<T>(string uri) {
            return ResolveResourceUri<T>(new Uri(uri));
        }
        
        public async Task<Dictionary<Uri, Dictionary<string, object>>> ResolveResourceUriMeta(IEnumerable<Uri> uris) {
            var result = new Dictionary<Uri, Dictionary<string, object>>();
            var tasks = new List<Task>();

            foreach (var uri in uris) {
                foreach (var it in uriMetaResolvers) {
                    foreach (var resolver in it.Value) {
                        tasks.Add(Task.Run(async () => {
                            try {
                                var task = resolver.Resolve(uri);
                                if (task == null) return;
                                var meta = await task;
                                if (meta == null) return;

                                lock (result) {
                                    result[uri] = meta;
                                }
                            } catch (Exception e) {
                                Log.UserError($"An error occurred when trying to resolve meta for resource URI {uri}", e);
                            }
                        }));
                    }
                }
            }
            await Task.WhenAll(tasks);
            return result;
        }

        public async Task<Dictionary<string, object>> ResolveResourceUriMeta(Uri uri) {
            var result = new Dictionary<string, object>();
            foreach (var it in uriMetaResolvers) {
                foreach (var resolver in it.Value) {
                    try {
                        var task = resolver.Resolve(uri);
                        if (task == null) {
                            continue;
                        }
                        var meta = await task;
                        if (meta != null) {
                            result = meta;
                            break;
                        }
                    } catch (Exception e) {
                        Log.Error($"An error occured when trying to resolve meta for resource URI {uri}", e);
                        throw;
                    }
                }
            }
            return result;
        }
        
        public async Task<byte[]> ResolveResourceUriThumbnail(Uri uri) {
            foreach (var resolver in uriThumbnailResolvers.SelectMany(it => it.Value)) {
                try {
                    var task = resolver.Resolve(uri);
                    if (task == null) {
                        continue;
                    }
                    var result = await task;
                    if (result != null) {
                        return result;
                    }
                } catch (Exception e) {
                    Log.Error($"An error occured when trying to resolve thumbnail for resource URI {uri}", e);
                    throw;
                }
            }
            return default;
        }

        public void Dispose() {
            providers.Clear();
            uriResolvers.Clear();
        }
        
    }
    
    [Serializable]
    public class ResourceProviderResult {
        public string providerName;
        public List<Resource> resources;
    }

    public static class ResourceUriProviderResultExtensions {
        public static AutoCompleteList ToAutoCompleteList(this List<ResourceProviderResult> results) {
            return new AutoCompleteList {
                categories = results.SelectMany(it => {
                    return it.resources.GroupBy(r => r.category).Select(group => {
                        return new AutoCompleteCategory {
                            title = group.Key == null ? it.providerName : $"{it.providerName}-->{group.Key}",
                            entries = group.Select(r => new AutoCompleteEntry {
                                label = r.label,
                                value = r.uri.ToString()
                            }).ToList()
                        };
                    });
                }).ToList()
            };
        }
    }

    [Serializable]
    public class Resource : ILocalizable {
        [CanBeNull]
        public string category;
        public string label;
        public Uri uri;
        
        public void Localize() {
            category = category.Localized();
            label = label.Localized();
        }
    }

    public interface IResourceProvider {
        public string ResourceProviderName { get; }
        public List<Resource> ProvideResources(string query);
    }

    public interface IResourceUriResolver {
        public object Resolve(Uri uri);
    }
    
    public interface IResourceUriMetaResolver {
        public Task<Dictionary<string, object>> Resolve(Uri uri);
    }

    public interface IResourceUriThumbnailResolver {
        public Task<byte[]> Resolve(Uri uri);
    }
}
