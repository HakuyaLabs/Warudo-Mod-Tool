using System;
using System.Collections.Generic;
using System.Linq;
using Cysharp.Threading.Tasks;
using UnityEngine;
using Warudo.Core.Attributes;
using Warudo.Core.Data;
using Warudo.Core.Graphs;
using Warudo.Core.Utils;
using Warudo.Plugins.Core.Assets;
using Warudo.Plugins.Core.Assets.Character;
using Warudo.Plugins.Core.Utils;
using System;
using Object = UnityEngine.Object;

namespace Warudo.Plugins.Core.Nodes
{
    public class OverrideCharacterBlendShapesNode : Node
    {
        protected virtual Dictionary<string, Dictionary<string, float>> TargetBlendShapes => throw new NotImplementedException();
        protected virtual Dictionary<string, Dictionary<string, object>> TargetMaterialProperties => throw new NotImplementedException();
        public CharacterAsset Character;
        public Dictionary<string, float> BlendShapes;
        public bool ApplyToAllSkinnedMeshes = true;
        protected bool HideApplyToAllSkinnedMeshes() => throw new NotImplementedException();
        public string TargetSkinnedMesh = "Body";
        protected bool HideTargetSkinnedMesh() => throw new NotImplementedException();
        public bool UseVRMBlendShapeProxy = false;
        protected bool HideUseVRMBlendShapeProxy() => throw new NotImplementedException();
        public string[] AdditiveVRMBlendShapeClips;
        public async UniTask<AutoCompleteList> AutoCompleteBlendShapes()
        {
            throw new NotImplementedException();
        }

        public bool ClampAllBlendShapes = true;
        public string[] ClampedBlendShapes;
        public string[] UnclampedBlendShapes;
        protected bool HideClampBlendShapes() => throw new NotImplementedException();
        protected bool HideUnclampedBlendShapes() => throw new NotImplementedException();
        interface IAccumulatingProperty
        {
            void Add(object value, float weight);
            void Reset();
            object AccumulatedValue { get; }

            object AdditiveValue { get; }
        }

        abstract class AccumulatingProperty<T> : IAccumulatingProperty
        {
            public readonly T baseValue;
            public readonly List<T> values = new();
            public readonly List<float> weights = new();
            public AccumulatingProperty(T baseValue)
            {
                throw new NotImplementedException();
            }

            protected abstract T Add(T a, T b);
            protected abstract T Minus(T a, T b);
            protected abstract T Multiply(T a, float b);
            public void Add(object value, float weight)
            {
                throw new NotImplementedException();
            }

            public void Reset()
            {
                throw new NotImplementedException();
            }

            public object AccumulatedValue
            {
                get
                {
                    throw new NotImplementedException();
                }
            }

            public object AdditiveValue
            {
                get
                {
                    throw new NotImplementedException();
                }
            }
        }

        class FloatAccumulatingProperty : AccumulatingProperty<float>
        {
            public FloatAccumulatingProperty(float baseValue) : base(baseValue)
            {
                throw new NotImplementedException();
            }

            protected override float Add(float a, float b) => throw new NotImplementedException();
            protected override float Minus(float a, float b) => throw new NotImplementedException();
            protected override float Multiply(float a, float b) => throw new NotImplementedException();
        }

        class ColorAccumulatingProperty : AccumulatingProperty<Color>
        {
            public ColorAccumulatingProperty(Color baseValue) : base(baseValue)
            {
                throw new NotImplementedException();
            }

            protected override Color Add(Color a, Color b) => throw new NotImplementedException();
            protected override Color Minus(Color a, Color b) => throw new NotImplementedException();
            protected override Color Multiply(Color a, float b) => throw new NotImplementedException();
        }

        class Vector4AccumulatingProperty : AccumulatingProperty<Vector4>
        {
            public Vector4AccumulatingProperty(Vector4 baseValue) : base(baseValue)
            {
                throw new NotImplementedException();
            }

            protected override Vector4 Add(Vector4 a, Vector4 b) => throw new NotImplementedException();
            protected override Vector4 Minus(Vector4 a, Vector4 b) => throw new NotImplementedException();
            protected override Vector4 Multiply(Vector4 a, float b) => throw new NotImplementedException();
        }

        class IntAccumulatingProperty : AccumulatingProperty<int>
        {
            public IntAccumulatingProperty(int baseValue) : base(baseValue)
            {
                throw new NotImplementedException();
            }

            protected override int Add(int a, int b) => throw new NotImplementedException();
            protected override int Minus(int a, int b) => throw new NotImplementedException();
            protected override int Multiply(int a, float b) => throw new NotImplementedException();
        }

        public Continuation Enter()
        {
            throw new NotImplementedException();
        }

        public Continuation Exit;
        protected override void OnCreate()
        {
            throw new NotImplementedException();
        }

        public override void OnUpdate()
        {
            throw new NotImplementedException();
        }

        public async UniTask<AutoCompleteList> AutoCompleteSkinnedMesh()
        {
            throw new NotImplementedException();
        }
    }
}