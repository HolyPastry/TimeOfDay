using System;
using UnityEngine;
using UnityEngine.Rendering;

namespace Bakery
{
    [Serializable]
    public class TodSunMoonSetting : TodSetting
    {
        [Header("The Sun and Moon")]
        public float SunMoonIntensity;
        public Quaternion SunMoonRotation;

        public float SunIntensity;
        public float MoonIntensity;

        [Header("SkyBox")]
        public float SkyboxRotation;

        [Header("SkyBox")]
        [SerializeField]
        private Material _skyboxMaterial;

        public override void Record()
        {
            (SunIntensity, MoonIntensity) = SunMoonController.GetIntensity();

            SunMoonIntensity = RenderSettings.haloStrength;

            SkyboxRotation = _skyboxMaterial.GetFloat("_TimeOfDay");

            SunMoonRotation = SunMoonController.GetRotation();
        }

        public override void Apply()
        {
            SunMoonController.SetIntensity(SunIntensity, MoonIntensity);

            _skyboxMaterial.SetFloat("_TimeOfDay", SkyboxRotation);
            SunMoonController.SetRotation(SunMoonRotation);
        }
    }
}
