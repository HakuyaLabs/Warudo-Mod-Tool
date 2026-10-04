using System.Collections.Generic;
using UnityEngine;
using System;
using Object = UnityEngine.Object;

namespace Animancer
{
    public class SpriteRendererTextureSwap : MonoBehaviour
    {
        public const int DefaultExecutionOrder = 30000;
        public ref SpriteRenderer Renderer => throw new NotImplementedException();
        public Texture2D Texture
        {
            get => throw new NotImplementedException();
            set
            {
                throw new NotImplementedException();
            }
        }

        protected virtual void Awake() => throw new NotImplementedException();
        protected virtual void OnValidate() => throw new NotImplementedException();
        protected virtual void LateUpdate()
        {
            throw new NotImplementedException();
        }

        public void ClearCache()
        {
            throw new NotImplementedException();
        }

        public static Dictionary<Sprite, Sprite> GetSpriteMap(Texture2D texture)
        {
            throw new NotImplementedException();
        }

        public static bool TrySwapTexture(Dictionary<Sprite, Sprite> spriteMap, Texture2D texture, ref Sprite sprite)
        {
            throw new NotImplementedException();
        }

        public static void DestroySprites(Dictionary<Sprite, Sprite> spriteMap)
        {
            throw new NotImplementedException();
        }

        public static void DestroySprites(Texture2D texture)
        {
            throw new NotImplementedException();
        }
    }
}