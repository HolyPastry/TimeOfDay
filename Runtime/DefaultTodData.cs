using UnityEngine;

namespace Bakery
{
    [CreateAssetMenu(fileName = "TodData", menuName = "Bakery/TOD/Data", order = 0)]
    public class DefaultTodData : AbstractTodData
    {
        public TodEnvironmentLighting _todEnvironmentLighting = new();
        public TodFogSetting _todFogSetting = new();
        public TodShadow _todShadow = new();
        public TodSunMoonSetting _todSunMoonSetting = new();

        public override void Apply()
        {
            _todEnvironmentLighting.Apply();
            _todFogSetting.Apply();
            _todSunMoonSetting.Apply();
            _todShadow.Apply();
        }

        public override void Record()
        {
            _todEnvironmentLighting.Record();
            _todFogSetting.Record();
            _todSunMoonSetting.Record();
            _todShadow.Record();
        }
    }
}
