using UnityEngine;
using Warudo.Core.Attributes;

namespace Warudo.Core.Data {
    public enum ToggleAction {
        [Label("TOGGLE")]
        Toggle,
        [Label("ENABLE")]
        Enable,
        [Label("DISABLE")]
        Disable
    }
    public static class ToggleActionExtensions {
        public static void ToggleActive(this GameObject gameObject, ToggleAction action) {
            if (action == ToggleAction.Disable) {
                gameObject.SetActive(false);
            } else if (action == ToggleAction.Enable) {
                gameObject.SetActive(true);
            } else {
                gameObject.SetActive(!gameObject.activeSelf);
            }
        }
    }
}
