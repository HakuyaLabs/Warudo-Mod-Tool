using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
using Warudo.Core.Utils;

namespace Warudo.Core.UI {
    public class ToastBehavior : MonoBehaviour {

        public Text text;
        public Image background;

        public int backgroundMaxHeight = 180;
        public float fadeDuration;
        public float textFadeDelay;

        private bool isEntered;
        private Queue<(string message, float duration)> queue = new();

        private void Reset() {
            text.SetAlpha(0);
            var sd = background.rectTransform.sizeDelta;
            sd.y = 0;
            background.rectTransform.sizeDelta = sd;
        }
        
        private void Awake() {
            Reset();
        }

        public void OnEnable() {
            Reset();
        }

        private async UniTask Enter() {
            background.rectTransform.DOSizeDelta(new Vector2(background.rectTransform.sizeDelta.x, backgroundMaxHeight), fadeDuration).SetEase(Ease.InCubic);
            await UniTask.Delay(TimeSpan.FromSeconds(textFadeDelay));
            await EnterText();
            isEntered = true;
        }
        
        private async UniTask Exit() {
            await ExitText();
            background.rectTransform.DOSizeDelta(new Vector2(background.rectTransform.sizeDelta.x, 0), fadeDuration).SetEase(Ease.OutCubic);
            await UniTask.Delay(TimeSpan.FromSeconds(fadeDuration));
            isEntered = false;
        }
        
        private async UniTask EnterText() {
            text.DOFade(1, fadeDuration).SetEase(Ease.OutCubic);
            await UniTask.Delay(TimeSpan.FromSeconds(fadeDuration));
        }
        
        private async UniTask ExitText() {
            text.DOFade(0, fadeDuration).SetEase(Ease.InCubic);
            await UniTask.Delay(TimeSpan.FromSeconds(fadeDuration));
        }

        private void Update() {
            UpdateToast();
        }

        private bool updatingToast;

        private async void UpdateToast() {
            if (updatingToast) return;
            updatingToast = true;
            if (queue.Count > 0) {
                var (message, duration) = queue.Dequeue();

                if (isEntered) await ExitText();
                text.text = message;
                if (!isEntered) await Enter();
                else await EnterText();
                    
                await UniTask.Delay(TimeSpan.FromSeconds(duration));
            } else {
                if (isEntered) await Exit();
            }
            updatingToast = false;
        }

        public void QueueMessage(string message, float duration) {
            queue.Enqueue((message, duration));
        }
        
        public void ClearMessageQueue() {
            queue.Clear();
        }

    }
}
