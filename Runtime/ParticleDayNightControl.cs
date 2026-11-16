using System.Collections.Generic;
using UnityEngine;

namespace Bakery
{
    public class ParticleDayNightControl : MonoBehaviour
    {
        [SerializeField]
        private List<ParticleSystem> _particleSystems;

        [SerializeField]
        private List<Light> _lights = new();

        [SerializeField]
        private float _normalAlpha;

        [SerializeField]
        private float _defaultIntensity = 1f;

        public void SetAlphaPerc(float perc)
        {
            _particleSystems.ForEach(particleSystem =>
            {
                particleSystem.gameObject.SetActive(perc > 0.01f);

                var main = particleSystem.main;
                var color = main.startColor.color;
                color.a = _normalAlpha * perc;
                main.startColor = color;
            });

            _lights.ForEach(light =>
            {
                light.enabled = perc > 0.01f;
                light.intensity = _defaultIntensity * perc;
            });
        }
    }
}
