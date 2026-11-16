using System;
using UnityEngine;

namespace Bakery
{
    [Serializable]
    public struct BackgroundMeshes
    {
        public Material Material;

        [Header("Day")]
        public Color DayColor;
        public Color DayFogColor;
        public float DayFogFade;
        public float DayFogHeight;

        [Header("Night")]
        public Color NightColor;
        public Color NightFogColor;
        public float NightFogFade;
        public float NightFogHeight;
    }
}
