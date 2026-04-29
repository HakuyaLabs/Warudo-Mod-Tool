using UnityEngine;
using Warudo.Core.Localization;

namespace Warudo.Core.UI {
    public class Toast {

        private ToastBehavior toastBehavior;

        public void Initialize() {
            var toast = Object.Instantiate(Resources.Load("UI/Toast") as GameObject);
            Object.DontDestroyOnLoad(toast);
            toastBehavior = toast.GetComponent<ToastBehavior>();
        }
        
        public void QueueMessage(string message, float duration = 5f) {
            toastBehavior.QueueMessage(message.Localized(), duration);
        }
        
        public void ClearMessageQueue() {
            toastBehavior.ClearMessageQueue();
        }

    }
}
