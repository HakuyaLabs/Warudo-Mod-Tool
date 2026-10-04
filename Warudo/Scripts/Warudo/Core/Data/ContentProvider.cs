using System;
using System.Collections.Generic;
using System.Reflection;
using Cysharp.Threading.Tasks;
using UnityEngine;
using Warudo.Core.Utils;

namespace Warudo.Core.Data {
    public abstract class ContentProvider<T> {
        private readonly Dictionary<Guid, Func<UniTask<T>>> registeredProviders = new();

        protected abstract string Name { get; }
        
        public void Register(Guid id, Func<UniTask<T>> provider) {
            if (registeredProviders.ContainsKey(id)) {
                throw new Exception($"{Name} provider {id} is already registered");
            }

            registeredProviders[id] = provider;
            
            // Debug.Log($"Registered {Name} provider {id}");
        }
        
        public void Register(Guid id, Func<T> provider) {
            if (registeredProviders.ContainsKey(id)) {
                throw new Exception($"{Name} provider {id} is already registered");
            }

            registeredProviders[id] = async () => provider();
            
            // Debug.Log($"Registered {Name} provider {id}");
        }

        public void Unregister(Guid id) {
            if (!registeredProviders.ContainsKey(id)) return;
            registeredProviders.Remove(id);
            
            // Debug.Log($"Unregistered {Name} provider {id}");
        }

        public void Dispose() {
            registeredProviders.Clear();
        }

        public async UniTask<T> Provide(Guid id) {
            if (registeredProviders.Count == 0) return default;
            try {
                return await registeredProviders[id]();
            }
            catch (Exception e) {
                Log.UserError($"Failed to provide {Name} for {id}", e);
                throw;
            }
        }
    }
}
