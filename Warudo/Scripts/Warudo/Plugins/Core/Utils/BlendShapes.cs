using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using VRM;
using Warudo.Core;
using Warudo.Core.Data;
using Warudo.Core.Utils;
using Warudo.Plugins.Core.Assets.Character;
using System;
using Object = UnityEngine.Object;

namespace Warudo.Plugins.Core.Utils
{
    public static class BlendShapes
    {
        public static readonly string[] ARKitBlendShapeNames = {"eyeBlinkLeft", "eyeBlinkRight", "eyeLookDownLeft", "eyeLookDownRight", "eyeLookInLeft", "eyeLookInRight", "eyeLookOutLeft", "eyeLookOutRight", "eyeLookUpLeft", "eyeLookUpRight", "eyeSquintLeft", "eyeSquintRight", "eyeWideLeft", "eyeWideRight", "jawLeft", "jawRight", "jawForward", "jawOpen", "mouthLeft", "mouthRight", "mouthSmileLeft", "mouthSmileRight", "mouthFrownLeft", "mouthFrownRight", "mouthDimpleLeft", "mouthDimpleRight", "mouthStretchLeft", "mouthStretchRight", "mouthPressLeft", "mouthPressRight", "mouthLowerDownLeft", "mouthLowerDownRight", "mouthUpperUpLeft", "mouthUpperUpRight", "mouthClose", "mouthFunnel", "mouthPucker", "mouthRollLower", "mouthRollUpper", "mouthShrugLower", "mouthShrugUpper", "browDownLeft", "browDownRight", "browOuterUpLeft", "browOuterUpRight", "browInnerUp", "cheekSquintLeft", "cheekSquintRight", "cheekPuff", "noseSneerLeft", "noseSneerRight", "tongueOut"};
        public static readonly string[] MMDBlendShapeNames = {"真面目", "困る", "にこり", "怒り", "上", "下", "まばたき", "笑い", "ウィンク", "ウィンク２", "ウィンク右", "ｳｨﾝｸ２右", "はぅ", "なごみ", "びっくり", "じと目", "なぬ！", "瞳小", "瞳縦", "瞳縦潰れ", "びっくり", "への字", "恐ろしい子！", "カメラ目", "はちゅ目", "星目", "はぁと", "涙", "猫目", "瞳全消し", "あ", "い", "う", "お", "▲", "∧", "ω", "ω□", "はんっ！", "ぺろっ", "えー", "にやり", "ぎゃーす", "がーん", "ギギギ", "あ２", "ああ", "いい", "おお", "青ざめ", "д", "八重歯左", "八重歯右", "ワ", "口角上げ", "口角下げ", "口横広げ", "口横狭め", "頬染め", "照れ", "赤面", };
        public static AutoCompleteList AutoCompleteCommonBlendShapes()
        {
            throw new NotImplementedException();
        }

        public static AutoCompleteList AutoCompleteARKitBlendShapes()
        {
            throw new NotImplementedException();
        }

        public static AutoCompleteList AutoCompleteMMDBlendShapes()
        {
            throw new NotImplementedException();
        }

        public static AutoCompleteList AutoCompleteSkinnedMeshRendererBlendShapes(SkinnedMeshRenderer smr, string prefix = null)
        {
            throw new NotImplementedException();
        }

        public static AutoCompleteList AutoCompleteCharacterBlendShapes(CharacterAsset character, string prefix = null)
        {
            throw new NotImplementedException();
        }

        public static AutoCompleteList AutoCompleteSkinnedMeshBlendShapes(Dictionary<string, SkinnedMeshRenderer> smrs, string smrName, string prefix = null)
        {
            throw new NotImplementedException();
        }

        public static AutoCompleteList AutoCompleteSkinnedMeshesBlendShapes(Dictionary<string, SkinnedMeshRenderer> smrs, string prefix = null)
        {
            throw new NotImplementedException();
        }

        public static AutoCompleteList AutoCompleteAllCharacterBlendShapes()
        {
            throw new NotImplementedException();
        }

        public static AutoCompleteList AutoCompleteCharacterVRMBlendShapeClips(CharacterAsset character)
        {
            throw new NotImplementedException();
        }

        public static AutoCompleteList AutoCompleteInputBlendShapes(Dictionary<string, float> blendShapes)
        {
            throw new NotImplementedException();
        }
    }
}