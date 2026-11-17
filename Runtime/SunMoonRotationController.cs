using System;
using System.Collections.Generic;
using UnityEngine;

namespace Bakery
{
    public class SunMoonController : MonoBehaviour
    {
        [SerializeField]
        private Light _sunLight;

        [SerializeField]
        private Light _moonLight;
        public static Action<Quaternion> SetRotation = delegate { };
        public static Func<Quaternion> GetRotation = () => Quaternion.identity;

        public static Action<float, float> SetIntensity = delegate { };
        public static Func<(float, float)> GetIntensity = () => (0, 0);

        void Awake()
        {
            SetRotation = (rotation) => transform.rotation = rotation;
            GetRotation = () => transform.rotation;
            SetIntensity = (sun, moon) =>
            {
                _sunLight.intensity = sun;
                _moonLight.intensity = moon;
            };
            GetIntensity = () => (_sunLight.intensity, _moonLight.intensity);
        }
    }
}
