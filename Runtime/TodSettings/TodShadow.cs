using System;
using UnityEngine;

namespace Bakery
{
    [Serializable]
    public class TodShadow : TodSetting
    {
        [Header("Realtime Shadow Color")]
        public Color RealtimeShadowColor;

        public override void Apply()
        {
            RenderSettings.subtractiveShadowColor = RealtimeShadowColor;
        }

        public override void Record()
        {
            RealtimeShadowColor = RenderSettings.subtractiveShadowColor;
        }
    }
}
