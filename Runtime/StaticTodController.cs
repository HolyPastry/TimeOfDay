using System.Linq;
using Bakery.Core;
using UnityEngine;
using UnityEngine.Rendering;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace Bakery
{
    public partial class StaticTodController : MonoBehaviour, IToDController
    {
        [SerializeField]
        private string _resourcePath = "";

        [SerializeField]
        private StaticTodData _todData;

        private DataCollection<StaticTodData> _collection;

        [Header("Volumes")]
        [SerializeField]
        private Volume _dayVolume;

        [SerializeField]
        private Volume _nightVolume;

        [Header("The Sun and Moon")]
        [SerializeField]
        private Light _moonLight;

        [SerializeField]
        private Light _sunLight;

        [SerializeField]
        private GameObject _fakeSun;

        [SerializeField]
        private GameObject _fakeMoon;

        [Header("SkyBox")]
        [SerializeField]
        private Material _skyboxMaterial;

        void Awake()
        {
            _collection = new(_resourcePath);
        }

        void OnEnable()
        {
            TOD.Controller = () => this;
        }

        void OnDisable()
        {
            TOD.Controller = TOD.UnregisterController;
        }

        [ContextMenu("Update TOD")]
        private void UpdateSettings()
        {
            UpdateSettings(_todData);
        }

        private void UpdateSettings(StaticTodData todData)
        {
            RotateTheSun(todData);
            UpdateAmbiantLight(todData);
        }

#if UNITY_EDITOR
        [ContextMenu("Record Settings")]
        private void RecordSettings()
        {
            _todData.SunIntensity = _sunLight.intensity;
            _todData.MoonIntensity = _moonLight.intensity;

            _todData.AmbiantLight = RenderSettings.ambientLight;
            _todData.EquatorColor = RenderSettings.ambientEquatorColor;
            _todData.GroundColor = RenderSettings.ambientGroundColor;
            _todData.SkyColor = RenderSettings.ambientSkyColor;

            _todData.RealtimeShadowColor = RenderSettings.subtractiveShadowColor;

            _todData.FogColor = RenderSettings.fogColor;
            _todData.SunMoonIntensity = RenderSettings.haloStrength;
            //RenderSettings.flareStrength =

            _todData.SkyboxRotation = _skyboxMaterial.GetFloat("_TimeOfDay");

            _todData.GlobalVolumeIntensity = _dayVolume.weight;

            _todData.SunMoonRotation = transform.rotation;

            EditorUtility.SetDirty(_todData);
            AssetDatabase.Refresh();
            AssetDatabase.SaveAssetIfDirty(_todData);
        }
#endif

        private void UpdateAmbiantLight(StaticTodData todData)
        {
            _sunLight.intensity = todData.SunIntensity;
            _moonLight.intensity = todData.MoonIntensity;

            RenderSettings.ambientLight = todData.AmbiantLight;
            RenderSettings.ambientEquatorColor = todData.EquatorColor;
            RenderSettings.ambientGroundColor = todData.GroundColor;
            RenderSettings.ambientSkyColor = todData.SkyColor;

            RenderSettings.subtractiveShadowColor = todData.RealtimeShadowColor;

            RenderSettings.fogColor = todData.FogColor;
            RenderSettings.haloStrength = todData.SunMoonIntensity;
            //RenderSettings.flareStrength =

            _skyboxMaterial.SetFloat("_TimeOfDay", todData.SkyboxRotation);

            _dayVolume.weight = todData.GlobalVolumeIntensity;
            _nightVolume.weight = 1 - _dayVolume.weight;
        }

        private void RotateTheSun(StaticTodData todData)
        {
            transform.rotation = todData.SunMoonRotation;
        }

        public void Set(Season season, PeriodOfDay periodOfDay, Weather weather)
        {
            var data = _collection.Data.Find(tod =>
                tod.Season == season && tod.PeriodOfDay == periodOfDay && tod.Weather == weather
            );
            if (data == null)
                data = _collection.Data.Find(tod =>
                    tod.Season == season && tod.PeriodOfDay == periodOfDay
                );

            if (data == null)
                data = _collection.Data.Find(tod => tod.Season == season);
            if (data == null)
                data = _collection.Data.FirstOrDefault(tod => true);
            if (data == null)
            {
                Debug.LogWarning("No Matching TOD Settings");
                return;
            }
            UpdateSettings(data);
            TOD.Events.OnChanged(season, periodOfDay, weather);
        }
    }
}
