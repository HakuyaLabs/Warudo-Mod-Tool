using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Warudo.Core.Utils {
    public static class Debouncer {
        
        public static Action<T> Create<T>(this Action<T> func, TimeSpan timeSpan = default) {
            if (timeSpan == default) {
                timeSpan = TimeSpan.FromMilliseconds(300);
            }
            CancellationTokenSource cancelTokenSource = null;

            async void Action(T arg) {
                cancelTokenSource?.Cancel();
                cancelTokenSource = new CancellationTokenSource();

                try {
                    await UniTask.Delay(timeSpan, cancellationToken: cancelTokenSource.Token);
                } catch (OperationCanceledException) {
                    // Ignore
                    return;
                }
                if (cancelTokenSource.IsCancellationRequested) return;
                
                try {
                    func(arg);
                } catch (Exception e) {
                    Debug.Log($"Debounced action threw an exception: {e}");
                    Debug.LogException(e);
                }
            }

            return Action;
        }
        
        public static Action Create(this Action func, TimeSpan timeSpan = default) {
            if (timeSpan == default) {
                timeSpan = TimeSpan.FromMilliseconds(300);
            }
            CancellationTokenSource cancelTokenSource = null;

            async void Action() {
                cancelTokenSource?.Cancel();
                cancelTokenSource = new CancellationTokenSource();

                try {
                    await UniTask.Delay(timeSpan, cancellationToken: cancelTokenSource.Token);
                } catch (OperationCanceledException) {
                    // Ignore
                    return;
                }
                if (cancelTokenSource.IsCancellationRequested) return;

                try {
                    func();
                } catch (Exception e) {
                    Debug.Log($"Debounced action threw an exception: {e}");
                    Debug.LogException(e);
                }
            }

            return Action;
        }

    }
}
