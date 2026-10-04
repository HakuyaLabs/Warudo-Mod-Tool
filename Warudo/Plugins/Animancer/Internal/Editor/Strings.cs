using Animancer.Units;
using UnityEngine;
using System;
using Object = UnityEngine.Object;

namespace Animancer
{
    public static class Strings
    {
        public const string ProductName = "Animancer";
        public const string MenuPrefix = ProductName + "/";
        public const string CreateMenuPrefix = "Assets/Create/" + MenuPrefix;
        public const string ExamplesMenuPrefix = MenuPrefix + "Examples/";
        public const string AnimancerToolsMenuPath = "Window/Animation/Animancer Tools";
        public const int AssetMenuOrder = 410;
        public const string UnityEditor = "UNITY_EDITOR";
        public const string Assertions = "UNITY_ASSERTIONS";
        public const string Indent = "    ";
        public const string ProOnlyTag = "";
        public const string MustBeFinite = "must not be NaN or Infinity";
        public static class DocsURLs
        {
            public const string Documentation = "https://kybernetik.com.au/animancer";
            public const string APIDocumentation = Documentation + "/api/" + nameof(Animancer);
            public const string ExampleAPIDocumentation = APIDocumentation + ".Examples.";
            public const string DeveloperEmail = "animancer@kybernetik.com.au";
            public const string LatestVersion = Documentation + "/latest-version.txt";
            public const string OptionalWarning = APIDocumentation + "/" + nameof(Animancer.OptionalWarning);
        }

        public static class Tooltips
        {
            public const string MiddleClickReset = "\n• Middle Click = reset to default value";
            public const string FadeDuration = ProOnlyTag + "The amount of time the transition will take, e.g:" + "\n• 0s = Instant" + "\n• 0.25s = quarter of a second (Default)" + "\n• 0.25x = quarter of the animation length" + "\n• " + AnimationTimeAttribute.Tooltip + MiddleClickReset;
            public const string Speed = ProOnlyTag + "How fast the animation will play, e.g:" + "\n• 0x = paused" + "\n• 1x = normal speed" + "\n• -2x = double speed backwards";
            public const string OptionalSpeed = Speed + "\n• Disabled = keep previous speed" + MiddleClickReset;
            public const string NormalizedStartTime = ProOnlyTag + "• Enabled = use " + nameof(FadeMode) + "." + nameof(FadeMode.FromStart) + " and always restart at this time." + "\n• Disabled = use " + nameof(FadeMode) + "." + nameof(FadeMode.FixedSpeed) + " and continue from the current time if already playing." + "\n• " + AnimationTimeAttribute.Tooltip;
            public const string EndTime = ProOnlyTag + "The time when the End Callback will be triggered." + "\n• " + AnimationTimeAttribute.Tooltip + "\n\nDisabling the toggle automates the value:" + "\n• Speed >= 0 ends at 1x" + "\n• Speed < 0 ends at 0x";
            public const string CallbackTime = ProOnlyTag + "The time when the Event Callback will be triggered." + "\n• " + AnimationTimeAttribute.Tooltip;
        }
    }
}