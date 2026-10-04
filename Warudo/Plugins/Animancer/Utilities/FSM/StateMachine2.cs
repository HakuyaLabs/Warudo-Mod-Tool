using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Object = UnityEngine.Object;

namespace Animancer.FSM
{
    public interface IKeyedStateMachine<TKey>
    {
        TKey CurrentKey { get; }

        TKey PreviousKey { get; }

        TKey NextKey { get; }

        object TrySetState(TKey key);
        object TryResetState(TKey key);
        object ForceSetState(TKey key);
    }

    public partial class StateMachine<TKey, TState> : StateMachine<TState>, IKeyedStateMachine<TKey>, IDictionary<TKey, TState> where TState : class, IState
    {
        public IDictionary<TKey, TState> Dictionary { get; set; }

        public TKey CurrentKey => throw new NotImplementedException();
        public TKey PreviousKey => throw new NotImplementedException();
        public TKey NextKey => throw new NotImplementedException();
        public StateMachine()
        {
            throw new NotImplementedException();
        }

        public StateMachine(IDictionary<TKey, TState> dictionary)
        {
            throw new NotImplementedException();
        }

        public StateMachine(TKey defaultKey, TState defaultState)
        {
            throw new NotImplementedException();
        }

        public StateMachine(IDictionary<TKey, TState> dictionary, TKey defaultKey, TState defaultState)
        {
            throw new NotImplementedException();
        }

        public override void InitializeAfterDeserialize()
        {
            throw new NotImplementedException();
        }

        public bool TrySetState(TKey key, TState state)
        {
            throw new NotImplementedException();
        }

        public TState TrySetState(TKey key)
        {
            throw new NotImplementedException();
        }

        object IKeyedStateMachine<TKey>.TrySetState(TKey key) => throw new NotImplementedException();
        public bool TryResetState(TKey key, TState state)
        {
            throw new NotImplementedException();
        }

        public TState TryResetState(TKey key)
        {
            throw new NotImplementedException();
        }

        object IKeyedStateMachine<TKey>.TryResetState(TKey key) => throw new NotImplementedException();
        public void ForceSetState(TKey key, TState state)
        {
            throw new NotImplementedException();
        }

        public TState ForceSetState(TKey key)
        {
            throw new NotImplementedException();
        }

        object IKeyedStateMachine<TKey>.ForceSetState(TKey key) => throw new NotImplementedException();
        public TState this[TKey key] { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public bool TryGetValue(TKey key, out TState state) => throw new NotImplementedException();
        public ICollection<TKey> Keys => throw new NotImplementedException();
        public ICollection<TState> Values => throw new NotImplementedException();
        public int Count => throw new NotImplementedException();
        public void Add(TKey key, TState state) => throw new NotImplementedException();
        public void Add(KeyValuePair<TKey, TState> item) => throw new NotImplementedException();
        public bool Remove(TKey key) => throw new NotImplementedException();
        public bool Remove(KeyValuePair<TKey, TState> item) => throw new NotImplementedException();
        public void Clear() => throw new NotImplementedException();
        public bool Contains(KeyValuePair<TKey, TState> item) => throw new NotImplementedException();
        public bool ContainsKey(TKey key) => throw new NotImplementedException();
        public IEnumerator<KeyValuePair<TKey, TState>> GetEnumerator() => throw new NotImplementedException();
        IEnumerator IEnumerable.GetEnumerator() => throw new NotImplementedException();
        public void CopyTo(KeyValuePair<TKey, TState>[] array, int arrayIndex) => throw new NotImplementedException();
        bool ICollection<KeyValuePair<TKey, TState>>.IsReadOnly => throw new NotImplementedException();
        public TState GetState(TKey key)
        {
            throw new NotImplementedException();
        }

        public void AddRange(TKey[] keys, TState[] states)
        {
            throw new NotImplementedException();
        }

        public void SetFakeKey(TKey key) => throw new NotImplementedException();
        public override string ToString() => throw new NotImplementedException();
    }
}