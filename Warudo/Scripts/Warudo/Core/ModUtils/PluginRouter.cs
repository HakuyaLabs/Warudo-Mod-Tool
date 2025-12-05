using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Warudo.Core.Data;
using Warudo.Core.Events;
using Warudo.Core.Plugins;
using Warudo.Core.Scenes;
using Warudo.Core.Utils;

namespace Warudo.Core.ModUtils
{
    public enum CommandResultStatus
    {
        SUCCESS,
        ENTITY_NOT_FOUND,
        COMMAND_NOT_FOUND,
        EXECUTION_ERROR
    }
    public class CommandResult<T>
    {
        public CommandResultStatus Status;
        public T Data;
    }
    
    /// <summary>
    /// Connection information for signal routing
    /// </summary>
    internal class SignalConnection
    {
        public Guid ConnectionId;
        public string SourceEntityTypeId; // The ID from the attribute (PluginAttribute.Id, AssetTypeAttribute.Id, or NodeTypeAttribute.Id)
        public Guid? SourceEntityInstanceId; // The actual Entity.Id of the source entity instance (null means accept from any instance)
        public string TargetEntityTypeId; // The ID from the attribute
        public string EventTypeName; // The full name of the event type (for cross-mod matching)
        public Type EventType; // The actual event type
        public Delegate Handler;
        public Guid EventBusHandle;
    }
    
    public class PluginRouter
    {
        private readonly Dictionary<Guid, SignalConnection> connections = new();
        private readonly EventBus signalEventBus = new();
        private readonly Dictionary<string, List<Action<SignalBase>>> eventTypeHandlers = new();


        // 命令注册信息
        private class CommandInfo
        {
            public Guid CommandId;
            public Entity Entity;
            public string CommandName;
            public Delegate Handler;
            public string ArgsSignature;
        }

        // entity -> List<CommandInfo>
        private readonly Dictionary<Entity, List<CommandInfo>> entityCommands = new();
        // commandId -> CommandInfo
        private readonly Dictionary<Guid, CommandInfo> commandIdMap = new();

        /// <summary>
        /// 注册命令到指定 Entity
        /// </summary>
        public Guid RegisterCommand<TArgs, TResult>(Entity entity, string commandName, Func<TArgs, TResult> handler)
            where TArgs : class, new()
        {
            if (entity == null || string.IsNullOrEmpty(commandName) || handler == null)
                throw new ArgumentException("Invalid arguments for RegisterCommand");

            var argsSignature = GetEventSignature(typeof(TArgs));
            var commandId = Guid.NewGuid();
            var info = new CommandInfo
            {
                CommandId = commandId,
                Entity = entity,
                CommandName = commandName,
                Handler = handler,
                ArgsSignature = argsSignature
            };
            if (!entityCommands.ContainsKey(entity))
                entityCommands[entity] = new List<CommandInfo>();
            entityCommands[entity].Add(info);
            commandIdMap[commandId] = info;
            return commandId;
        }

        /// <summary>
        /// 注销命令
        /// </summary>
        public void UnregisterCommand(Guid commandId)
        {
            if (!commandIdMap.TryGetValue(commandId, out var info))
                return;
            var entity = info.Entity;
            if (entityCommands.TryGetValue(entity, out var list))
            {
                list.RemoveAll(c => c.CommandId == commandId);
                if (list.Count == 0)
                    entityCommands.Remove(entity);
            }
            commandIdMap.Remove(commandId);
        }

        /// <summary>
        /// 执行命令
        /// </summary>
        public CommandResult<TResult> ExecuteCommand<TArgs, TResult>(Entity entity, string commandName, TArgs args)
            where TArgs : class, new()
        {
            var result = new CommandResult<TResult>();
            if (entity == null)
            {
                result.Status = CommandResultStatus.ENTITY_NOT_FOUND;
                return result;
            }
            
            if (!entityCommands.TryGetValue(entity, out var commands))
            {
                result.Status = CommandResultStatus.ENTITY_NOT_FOUND;
                return result;
            }
            
            var argsSignature = GetEventSignature(typeof(TArgs));
            var cmd = commands.FirstOrDefault(c => c.CommandName == commandName && c.ArgsSignature == argsSignature);
            if (cmd == null)
            {
                result.Status = CommandResultStatus.COMMAND_NOT_FOUND;
                return result;
            }
            
            // 检查参数字段完全匹配
            if (!IsExactSignatureMatch(args, cmd.ArgsSignature))
            {
                result.Status = CommandResultStatus.COMMAND_NOT_FOUND;
                return result;
            }
            
            try
            {
                // Try direct cast first (for same-assembly scenarios)
                var func = cmd.Handler as Func<TArgs, TResult>;
                if (func != null)
                {
                    result.Data = func(args);
                    result.Status = CommandResultStatus.SUCCESS;
                    return result;
                }
                
                // If direct cast fails, perform cross-assembly type conversion
                // Get the handler's argument and return types
                var handlerType = cmd.Handler.GetType();
                var handlerMethod = handlerType.GetMethod("Invoke");
                if (handlerMethod == null)
                {
                    result.Status = CommandResultStatus.EXECUTION_ERROR;
                    return result;
                }
                
                var handlerArgType = handlerMethod.GetParameters()[0].ParameterType;
                var handlerReturnType = handlerMethod.ReturnType;
                
                // Convert TArgs to handler's argument type
                object convertedArgs = args;
                if (handlerArgType != typeof(TArgs))
                {
                    try
                    {
                        convertedArgs = Activator.CreateInstance(handlerArgType);
                        if (!CopyProperties(args, convertedArgs))
                        {
                            UnityEngine.Debug.LogError($"Failed to convert args from {typeof(TArgs).FullName} to {handlerArgType.FullName}");
                            result.Status = CommandResultStatus.EXECUTION_ERROR;
                            return result;
                        }
                    }
                    catch (Exception ex)
                    {
                        UnityEngine.Debug.LogError($"Failed to create instance of {handlerArgType.FullName}: {ex}");
                        result.Status = CommandResultStatus.EXECUTION_ERROR;
                        return result;
                    }
                }
                
                // Invoke the handler with converted args
                var handlerResult = cmd.Handler.DynamicInvoke(convertedArgs);
                
                // Convert handler's return value to TResult
                if (handlerResult == null)
                {
                    result.Data = default(TResult);
                }
                else if (handlerResult is TResult directResult)
                {
                    result.Data = directResult;
                }
                else if (handlerReturnType != typeof(TResult))
                {
                    try
                    {
                        var convertedResult = Activator.CreateInstance<TResult>();
                        if (!CopyProperties(handlerResult, convertedResult))
                        {
                            UnityEngine.Debug.LogError($"Failed to convert result from {handlerReturnType.FullName} to {typeof(TResult).FullName}");
                            result.Status = CommandResultStatus.EXECUTION_ERROR;
                            return result;
                        }
                        result.Data = convertedResult;
                    }
                    catch (Exception ex)
                    {
                        UnityEngine.Debug.LogError($"Failed to convert result: {ex}");
                        result.Status = CommandResultStatus.EXECUTION_ERROR;
                        return result;
                    }
                }
                else
                {
                    result.Data = (TResult)handlerResult;
                }
                
                result.Status = CommandResultStatus.SUCCESS;
            }
            catch(Exception ex)
            {
               UnityEngine.Debug.LogError(ex);
               result.Status = CommandResultStatus.EXECUTION_ERROR;
            }
            return result;
        }

        // 检查参数字段是否与 signature 完全一致（不能多不能少）
        private bool IsExactSignatureMatch(object args, string signature)
        {
            var type = args.GetType();
            var sig = GetEventSignature(type);
            return sig == signature;
        }
        
        /// <summary>
        /// Emit a signal from an entity (broadcast to all listeners)
        /// </summary>
        /// <param name="sourceEntity">The entity sending the signal</param>
        /// <param name="signalData">The signal data</param>
        public void EmitSignal<T>(Entity sourceEntity, T signalData) where T : Warudo.Core.Events.Event
        {
            var sourceEntityTypeId = GetEntityAttributeId(sourceEntity);
            if (sourceEntityTypeId == null)
            {
                throw new ArgumentException($"Entity {sourceEntity.GetType().Name} does not have a valid Plugin/Asset/Node attribute with an Id field.");
            }

            var eventSignature = GetEventSignature(typeof(T)); // Use signature based on field/property names and types
            var signal = new SignalBase
            {
                EntityTypeId = sourceEntityTypeId,
                EventTypeName = eventSignature,
                Data = signalData,
                EntityInstance = sourceEntity ?? null
            };
            
            // Broadcast to all handlers (they will filter by signature)
            foreach (var kvp in eventTypeHandlers)
            {
                foreach (var handler in kvp.Value.ToList()) // ToList to avoid modification during iteration
                {
                    handler(signal);
                }
            }
        }

        /// <summary>
        /// Connect a slot to receive signals from a specific entity type and optionally specific instance
        /// </summary>
        /// <param name="targetEntity">The entity that will receive signals</param>
        /// <param name="sourceEntityTypeId">The source entity type ID (from Attribute) to listen to</param>
        /// <param name="handler">The event handler</param>
        /// <returns>Connection handle that can be used to disconnect</returns>
        public delegate void OnSignal<T>(T data, Entity? source) where T : Warudo.Core.Events.Event;

        public Guid ConnectSlot<T>(Entity targetEntity, string sourceEntityTypeId, OnSignal<T> handler) where T : Warudo.Core.Events.Event
        {
            var connectionId = Guid.NewGuid();
            var expectedSignature = GetEventSignature(typeof(T));

            // Create a wrapper handler that filters by event signature and source type only
            Action<SignalBase> signalHandler = (signal) =>
            {
                bool sourceTypeMatch = signal.EntityTypeId == sourceEntityTypeId;
                if (sourceTypeMatch)
                {
                    var signalSignature = signal.EventTypeName;
                    bool signatureMatch = signalSignature == expectedSignature || AreSignaturesCompatible(signalSignature, expectedSignature);
                    if (signatureMatch)
                    {
                        T typedData = null;
                        if (signal.Data is T direct)
                        {
                            typedData = direct;
                        }
                        else if (signal.Data != null)
                        {
                            try
                            {
                                var targetData = Activator.CreateInstance<T>();
                                if (CopyProperties(signal.Data, targetData))
                                {
                                    typedData = targetData;
                                }
                            }
                            catch (Exception ex)
                            {
                                UnityEngine.Debug.LogWarning($"Failed to convert signal data from {signal.Data.GetType().Name} to {typeof(T).Name}: {ex.Message}");
                            }
                        }
                        if (typedData != null)
                        {
                            // 保证 source 不为 null
                            var source = signal.EntityInstance;
                            if (source == null)
                            {
                                UnityEngine.Debug.LogWarning("Signal EntityInstance is null. Please check EmitSignal usage.");
                            }
                            handler(typedData, source);
                        }
                    }
                }
            };

            var handlerKey = $"{sourceEntityTypeId}_{expectedSignature}";
            if (!eventTypeHandlers.ContainsKey(handlerKey))
            {
                eventTypeHandlers[handlerKey] = new List<Action<SignalBase>>();
            }
            eventTypeHandlers[handlerKey].Add(signalHandler);

            var connection = new SignalConnection
            {
                ConnectionId = connectionId,
                SourceEntityTypeId = sourceEntityTypeId,
                TargetEntityTypeId = GetEntityAttributeId(targetEntity),
                EventTypeName = handlerKey,
                EventType = typeof(T),
                Handler = signalHandler,
                EventBusHandle = Guid.Empty
            };

            connections[connectionId] = connection;
            return connectionId;
        }

        /// <summary>
        /// Disconnect a previously connected slot
        /// </summary>
        /// <param name="connectionId">The connection handle returned from ConnectSlot</param>
        public void DisconnectSlot(Guid connectionId)
        {
            if (!connections.TryGetValue(connectionId, out var connection))
            {
                return;
            }

            // Remove handler from event type handlers
            if (eventTypeHandlers.TryGetValue(connection.EventTypeName, out var handlers))
            {
                handlers.Remove((Action<SignalBase>)connection.Handler);
                if (handlers.Count == 0)
                {
                    eventTypeHandlers.Remove(connection.EventTypeName);
                }
            }
            
            connections.Remove(connectionId);
        }
        
        /// <summary>
        /// Generate a signature for an event type based on its fields and properties
        /// This allows matching events with the same structure but different class names
        /// </summary>
        private string GetEventSignature(Type eventType)
        {
            var signature = new System.Text.StringBuilder();
            
            // Get all public instance fields, sorted by name for consistency
            var fields = eventType.GetFields(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance)
                .OrderBy(f => f.Name)
                .ToList();
            
            // Get all public instance properties, sorted by name for consistency
            var properties = eventType.GetProperties(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance)
                .Where(p => p.CanRead && p.CanWrite)
                .OrderBy(p => p.Name)
                .ToList();
            
            foreach (var field in fields)
            {
                signature.Append($"{field.Name}:{field.FieldType.FullName};");
            }
            
            foreach (var prop in properties)
            {
                signature.Append($"{prop.Name}:{prop.PropertyType.FullName};");
            }
            
            return signature.ToString();
        }
        
        /// <summary>
        /// Check if two event signatures are compatible (have overlapping fields/properties)
        /// </summary>
        private bool AreSignaturesCompatible(string signature1, string signature2)
        {
            if (signature1 == signature2) return true;
            
            var parts1 = signature1.Split(';').Where(s => !string.IsNullOrEmpty(s)).ToHashSet();
            var parts2 = signature2.Split(';').Where(s => !string.IsNullOrEmpty(s)).ToHashSet();
            
            // Check if there's at least one common field/property
            return parts1.Overlaps(parts2);
        }
        
        /// <summary>
        /// Copy properties from source object to target object (for cross-mod event compatibility)
        /// Returns true if at least one field/property was successfully copied
        /// </summary>
        private bool CopyProperties(object source, object target)
        {
            var sourceType = source.GetType();
            var targetType = target.GetType();
            var copiedCount = 0;
            
            // Copy public instance properties
            foreach (var sourceProp in sourceType.GetProperties(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance))
            {
                if (!sourceProp.CanRead) continue;
                
                var targetProp = targetType.GetProperty(sourceProp.Name, System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance);
                if (targetProp != null && targetProp.CanWrite)
                {
                    // Check if types are compatible (exact match or assignable)
                    if (targetProp.PropertyType == sourceProp.PropertyType || 
                        targetProp.PropertyType.IsAssignableFrom(sourceProp.PropertyType))
                    {
                        try
                        {
                            var value = sourceProp.GetValue(source);
                            targetProp.SetValue(target, value);
                            copiedCount++;
                        }
                        catch (Exception ex)
                        {
                            UnityEngine.Debug.LogWarning($"Failed to copy property {sourceProp.Name}: {ex.Message}");
                        }
                    }
                }
            }
            
            // Copy public instance fields
            foreach (var sourceField in sourceType.GetFields(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance))
            {
                var targetField = targetType.GetField(sourceField.Name, System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance);
                if (targetField != null)
                {
                    // Check if types are compatible (exact match or assignable)
                    if (targetField.FieldType == sourceField.FieldType || 
                        targetField.FieldType.IsAssignableFrom(sourceField.FieldType))
                    {
                        try
                        {
                            var value = sourceField.GetValue(source);
                            targetField.SetValue(target, value);
                            copiedCount++;
                        }
                        catch (Exception ex)
                        {
                            UnityEngine.Debug.LogWarning($"Failed to copy field {sourceField.Name}: {ex.Message}");
                        }
                    }
                }
            }
            
            return copiedCount > 0;
        }

        /// <summary>
        /// Get the entity ID from its attribute (PluginAttribute, AssetTypeAttribute, or NodeTypeAttribute)
        /// </summary>
        private string GetEntityAttributeId(Entity entity)
        {
            var type = entity.GetType();

            // Check for PluginTypeAttribute
            if (entity is Plugin)
            {
                var pluginAttr = type.GetCustomAttributes(typeof(Warudo.Core.Attributes.PluginTypeAttribute), false)
                    .FirstOrDefault() as Warudo.Core.Attributes.PluginTypeAttribute;
                return pluginAttr?.Id;
            }

            // Check for AssetTypeAttribute
            if (entity is Asset)
            {
                var assetAttr = type.GetCustomAttributes(typeof(Warudo.Core.Attributes.AssetTypeAttribute), false)
                    .FirstOrDefault() as Warudo.Core.Attributes.AssetTypeAttribute;
                return assetAttr?.Id;
            }

            // Check for NodeTypeAttribute
            if (entity is Warudo.Core.Graphs.Node)
            {
                var nodeAttr = type.GetCustomAttributes(typeof(Warudo.Core.Attributes.NodeTypeAttribute), false)
                    .FirstOrDefault() as Warudo.Core.Attributes.NodeTypeAttribute;
                return nodeAttr?.Id;
            }

            return null;
        }
    }
}