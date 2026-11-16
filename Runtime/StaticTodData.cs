using UnityEngine;

namespace Bakery
{
    [CreateAssetMenu(fileName = "StaticToD", menuName = "Bakery/TOD/StaticData", order = 0)]
    public class StaticTodData : ScriptableObject
    {
        [Header("Parameters")]
        public Season Season;
        public PeriodOfDay PeriodOfDay;
        public Weather Weather;

        [Header("Environment Lighting")]
        public Color AmbiantLight;
        public Color EquatorColor;
        public Color GroundColor;
        public Color SkyColor;

        [Header("Realtime Shadow Color")]
        public Color RealtimeShadowColor;

        [Header("Fog")]
        public Color FogColor;
        public float HaloStrengthGradient;
        public float FlareStrengthGradient;

        [Header("Global Volumes")]
        public float GlobalVolumeIntensity;

        [Header("The Sun and Moon")]
        public float SunMoonIntensity;
        public Quaternion SunMoonRotation;

        public float SunIntensity;
        public float MoonIntensity;

        [Header("SkyBox")]
        public float SkyboxRotation;

        [Header("GameObjects")]
        public int Dawn = 6;
        public int Day = 8;
        public int Dusk = 18;
        public int Night = 20;

        [Header("ParticleSystem")]
        public float DayParticleIntensityCurve;
        public float NightParticleIntensityCurve;

        public float DuskParticleIntensityCurve;
        public float DawnParticleIntensityCurve;

        [Header("Material Swaps")]
        public float MeshRendererIntensityCurve;
    }
}
