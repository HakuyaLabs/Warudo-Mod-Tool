using System;
using UnityEngine;
using Event = Warudo.Core.Events.Event;

namespace Warudo.Core.Rendering {
    public class RenderingPipelineManager {

        public RenderingPipeline CurrentPipeline => QualitySettings.GetQualityLevel() switch {
            0 => RenderingPipeline.BiRP,
            1 => RenderingPipeline.URP,
            _ => throw new ArgumentOutOfRangeException()
        };

        private RenderingPipeline lastRenderingPipeline;

        public void Initialize() {
            lastRenderingPipeline = CurrentPipeline;
        }

        public void OnEndOfFrame() {
            if (lastRenderingPipeline != CurrentPipeline) {
                lastRenderingPipeline = CurrentPipeline;
                Context.EventBus.Broadcast(new RenderingPipelineChangeEvent(lastRenderingPipeline));
            }
        }
        
        public void SetPipeline(RenderingPipeline pipeline) {
            QualitySettings.SetQualityLevel((int) pipeline);
            lastRenderingPipeline = pipeline;
            Context.EventBus.Broadcast(new RenderingPipelineChangeEvent(pipeline));
        }

    }
    
    public enum RenderingPipeline {
        BiRP,
        URP
    }
    
    public class RenderingPipelineChangeEvent : Event {
        public RenderingPipeline NewPipeline { get; }
        
        public RenderingPipelineChangeEvent(RenderingPipeline newPipeline) {
            NewPipeline = newPipeline;
        }
    }
}
