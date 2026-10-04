using System;
using Cysharp.Threading.Tasks;
using UnityEngine;
using Warudo.Core.Utils;
using Warudo.Core.Attributes;
using System;
using Object = UnityEngine.Object;

namespace Warudo.Core.Rendering
{
    public class MaterialMapper : MonoBehaviour
    {
        public Material[] birpMaterials;
        public Material[] urpMaterials;
        public void OnRenderingPipelineChange(RenderingPipeline pipeline)
        {
            throw new NotImplementedException();
        }

        public void UseURPMaterials()
        {
            throw new NotImplementedException();
        }

        public void UseBiRPMaterials()
        {
            throw new NotImplementedException();
        }
    }
}