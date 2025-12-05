using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;
using Vexe.Fast.Reflection;
using Warudo.Core.Graphs;
using Warudo.Core.Utils;

namespace Warudo.Core.Data {
    public abstract class EntityTypeRegistry<T, TMeta, TCheckpoint> where T : Entity where TMeta : EntityTypeMeta, new() where TCheckpoint : TypeCheckpoint {

        protected readonly Dictionary<string, TMeta> RegisteredTypes = new();

        protected virtual TMeta CreateMeta(string id, Type type) {
            var meta = new TMeta {
                Id = id,
                Type = type
            };

            foreach (var fieldInfo in type.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)) {
                var dataInputPortTypeMeta = DataInputPort.GetReflectionMeta(fieldInfo);
                if (dataInputPortTypeMeta != null) {
                    meta.DataInputs.Add(dataInputPortTypeMeta);
                }
            }
            foreach (var methodInfo in type.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)) {
                var triggerPortTypeMeta = TriggerPort.GetReflectionMeta(methodInfo);
                if (triggerPortTypeMeta != null) {
                    meta.Triggers.Add(triggerPortTypeMeta);
                }
            }
            foreach (var fieldInfo in type.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)) {
                var mixinMeta = Mixin.GetReflectionMeta(fieldInfo);
                if (mixinMeta != null) {
                    meta.Mixins.Add(mixinMeta);
                }
            }
            
            return meta;
        }

        public virtual TMeta RegisterType(string id, Type type) {
            if (!type.InheritsFrom(typeof(T))) {
                throw new Exception($"Type {type.Name} is not a {typeof(T).Name} type");
            }
            if (type.IsAbstract || type.IsInterface) {
                throw new Exception($"Type {type.Name} must be a concrete type");
            }
            if (type.GetConstructors().All(it => it.GetParameters().Length != 0)) {
                throw new Exception($"Type {type.Name} must have a parameterless constructor");
            }

            var existingType = RegisteredTypes.Values.FirstOrDefault(it => it.Id == id);
            if (existingType != null) {
                throw new Exception($"{typeof(T).Name} type ID {id} is already used");
            }

            var meta = CreateMeta(id, type);
            RegisteredTypes[id] = meta;
            
            Debug.Log($"Registered {typeof(T).Name} type {type.Name}");
            return meta;
        }
        
        public TCheckpoint CheckpointType(string id, bool unregister = true) {
            var checkpoint = CreateTypeCheckpoint(id);

            if (unregister) {
                var existingType = GetTypeMeta(id);
                if (existingType != null) {
                    UnregisterType(existingType.Type);
                }
            }

            return checkpoint;
        }
        
        public bool IsTypeRegistered(string id) {
            return GetTypeMeta(id) != null;
        }
        
        public bool IsTypeRegistered(Type type) {
            return GetTypeMeta(type) != null;
        }
        
        public virtual void UnregisterType(string id) {
            var meta = GetTypeMeta(id);
            if (meta == null) {
                throw new Exception($"{typeof(T).Name} type with ID {id} is not registered");
            }
            RegisteredTypes.Remove(id);
        }
        
        public void UnregisterType(Type type) {
            var meta = GetTypeMeta(type);
            if (meta == null) {
                throw new Exception($"{typeof(T).Name} type with type {type.Name} is not registered");
            }
            UnregisterType(meta.Id);
        }

        public virtual T CreateEntity(string id, Action<T> initializer = null) {
            var meta = GetTypeMeta(id);
            if (meta == null) {
                throw new Exception($"Cannot find {typeof(T).Name} type with ID {id}. Is it registered?");
            }
            var entity = (T) meta.Type.DelegateForCtor().Invoke(Array.Empty<object>());
            initializer?.Invoke(entity);
            entity.Create();
            // Debug.Log($"Created entity {typeof(T).Name} with ID {id}");
            return entity;
        }

        public T CreateEntity(Type type) {
            var meta = GetTypeMeta(type);
            if (meta == null) {
                throw new Exception($"Cannot find {typeof(T).Name} type with type {type.Name}. Is it registered?");
            }
            return CreateEntity(meta.Id);
        }

        public virtual void Dispose() {
            RegisteredTypes.Clear();
        }
        
        public virtual TMeta GetTypeMeta(Type type) => RegisteredTypes.Values.FirstOrDefault(it => it.Type == type);

        public virtual TMeta GetTypeMeta(string typeId) => RegisteredTypes.Values.FirstOrDefault(it => it.Id == typeId);
        
        public Dictionary<string, TMeta> GetRegisteredTypes() => RegisteredTypes;

        public virtual TCheckpoint CreateTypeCheckpoint(string id) => null;

        public virtual void RestoreTypeCheckpoint(TCheckpoint checkpoint) {
        }
    }

    public abstract class EntityTypeRegistry<T, TMeta> : EntityTypeRegistry<T, TMeta, TypeCheckpoint> where T : Entity where TMeta : EntityTypeMeta, new() {
    }

    public abstract class TypeCheckpoint {
        public string Id;
    }
}
