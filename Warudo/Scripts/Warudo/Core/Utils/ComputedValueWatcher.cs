using System;
using UnityEngine;

namespace Warudo.Core.Utils {
    public abstract class ComputedValueWatcher {
        public abstract void Evaluate();
    }
    public class ComputedValueWatcher<T> : ComputedValueWatcher {

        private bool hasEvaluatedOnce;
        private readonly Func<T> valueComputer;
        private readonly Func<T> storeGetter;
        private readonly Action<T> storeSetter;
        private readonly Action<T> onChanged;

        public ComputedValueWatcher(Func<T> valueComputer, Func<T> storeGetter, Action<T> storeSetter, Action<T> onChanged) {
            this.valueComputer = valueComputer;
            this.storeGetter = storeGetter;
            this.storeSetter = storeSetter;
            this.onChanged = onChanged;
        }

        public override void Evaluate() {
            try {
                var result = valueComputer();
                if (!Equals(result, storeGetter()) || !hasEvaluatedOnce) {
                    hasEvaluatedOnce = true;
                    storeSetter(result);
                    onChanged(result);
                }
            } catch (Exception e) {
                Log.Error("Error evaluating watcher computed value: " + e);
            }
        }
        
    }
}
