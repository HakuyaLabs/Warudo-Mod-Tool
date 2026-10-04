using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Warudo.Core.Utils {
    public static class Throttler {
        public static Action<T> Create<T>(Action<T> func, TimeSpan timeSpan = default) {
            if (timeSpan == default) {
                timeSpan = TimeSpan.FromMilliseconds(300);
            }

            CancellationTokenSource cancelTokenSource = null;
            DateTime lastExecutionTime = DateTime.MinValue;

            async void Action(T arg) {
                DateTime now = DateTime.UtcNow;
                TimeSpan timeSinceLastExecution = now - lastExecutionTime;

                if (timeSinceLastExecution < timeSpan) {
                    cancelTokenSource?.Cancel();
                    cancelTokenSource = new CancellationTokenSource();

                    try {
                        await UniTask.Delay(timeSpan - timeSinceLastExecution, cancellationToken: cancelTokenSource.Token);
                    } catch (OperationCanceledException) {
                        return;
                    }
                }

                lastExecutionTime = DateTime.UtcNow;

                try {
                    func(arg);
                } catch (Exception e) {
                    Debug.Log($"Throttled action threw an exception: {e}");
                    Debug.LogException(e);
                }
            }

            return Action;
        }

        public static Action Create(Action func, TimeSpan timeSpan = default) {
            if (timeSpan == default) {
                timeSpan = TimeSpan.FromMilliseconds(300);
            }

            CancellationTokenSource cancelTokenSource = null;
            DateTime lastExecutionTime = DateTime.MinValue;

            async void Action() {
                DateTime now = DateTime.UtcNow;
                TimeSpan timeSinceLastExecution = now - lastExecutionTime;

                if (timeSinceLastExecution < timeSpan) {
                    cancelTokenSource?.Cancel();
                    cancelTokenSource = new CancellationTokenSource();

                    try {
                        await UniTask.Delay(timeSpan - timeSinceLastExecution, cancellationToken: cancelTokenSource.Token);
                    } catch (OperationCanceledException) {
                        return;
                    }
                }

                lastExecutionTime = DateTime.UtcNow;

                try {
                    func();
                } catch (Exception e) {
                    Debug.Log($"Throttled action threw an exception: {e}");
                    Debug.LogException(e);
                }
            }

            return Action;
        }
    }
}
