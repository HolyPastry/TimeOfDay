using System;
using UnityEngine;

namespace Bakery
{
    [Serializable]
    public class TodEnvironmentLighting : TodSetting
    {
        [Header("Environment Lighting")]
        public Color AmbiantLight;
        public Color EquatorColor;
        public Color GroundColor;
        public Color SkyColor;

        public override void Apply()
        {
            RenderSettings.ambientLight = AmbiantLight;
            RenderSettings.ambientEquatorColor = EquatorColor;
            RenderSettings.ambientGroundColor = GroundColor;
            RenderSettings.ambientSkyColor = SkyColor;
        }

        public override void Record()
        {
            AmbiantLight = RenderSettings.ambientLight;
            EquatorColor = RenderSettings.ambientEquatorColor;
            GroundColor = RenderSettings.ambientGroundColor;
            SkyColor = RenderSettings.ambientSkyColor;
        }
    }
}
