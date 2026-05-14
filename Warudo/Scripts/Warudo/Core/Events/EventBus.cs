using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Warudo.Core.Utils;

namespace Warudo.Core.Events {
	public class EventBus {

		private readonly Dictionary<Type, HashSet<(Guid handle, Delegate handler)>> eventHandlers = new();

		public Guid Subscribe<T>(OnEvent<T> handler) where T : Event {
			if (!eventHandlers.ContainsKey(typeof(T))) {
				eventHandlers[typeof(T)] = new();
			}

			var handle = Guid.NewGuid();
			eventHandlers[typeof(T)].Add((handle, handler));
			return handle;
		}

		public Guid Subscribe(Type type, Action<Event> handler) {
			if (!eventHandlers.ContainsKey(type)) {
				eventHandlers[type] = new();
			}
			
			var handle = Guid.NewGuid();
			eventHandlers[type].Add((handle, handler));
			return handle;
		}

		public void Unsubscribe<T>(Guid handle) where T : Event {
			Unsubscribe(typeof(T), handle);
		}
		
		public void Unsubscribe(Type type, Guid handle) {
			if (!eventHandlers.ContainsKey(type)) return;

			var removal = eventHandlers[type].FirstOrDefault(it => it.handle == handle);
			if (removal != default) {
				eventHandlers[type].Remove(removal);
			}

			if (eventHandlers[type].Count == 0) {
				eventHandlers.Remove(type);
			}
		}

		public void UnsubscribeAll() {
			eventHandlers.Clear();
		}

		public void Broadcast<T>(T e) where T : Event {
			if (!eventHandlers.ContainsKey(typeof(T))) return;

			foreach (var (_, handler) in eventHandlers[typeof(T)]) {
				switch (handler) {
					case OnEvent<T> onEvent:
						try {
							onEvent.Invoke(e);
						} catch (Exception ex) {
							Log.Error($"An exception was thrown by one of the {e.GetType().Name} handlers", ex);
						}
						break;
					case Action<Event> action:
						try {
							action.Invoke(e);
						} catch (Exception ex) {
							Log.Error($"An exception was thrown by one of the {e.GetType().Name} handlers", ex);
						}
						break;
					default:
						throw new InvalidOperationException();
				}
			}
		}

	}
}
