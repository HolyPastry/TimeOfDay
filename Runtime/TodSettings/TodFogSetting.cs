using System;
using UnityEngine;

namespace Bakery
{
    [Serializable]
    public class TodFogSetting : TodSetting
    {
        [Header("Fog")]
        public Color FogColor;
        public float HaloStrength;
        public float FlareStrength;

        public override void Apply()
        {
            RenderSettings.fogColor = FogColor;
            RenderSettings.haloStrength = HaloStrength;
        }

        public override void Record()
        {
            FogColor = RenderSettings.fogColor;
            HaloStrength = RenderSettings.haloStrength;
        }
    }
}
