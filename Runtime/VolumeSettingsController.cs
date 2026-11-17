using UnityEngine;
using UnityEngine.Rendering;

namespace Bakery
{
    [RequireComponent(typeof(Volume))]
    public class VolumeSettingsController : TodFilteredComponent
    {
        private Volume _volume;

        void Awake()
        {
            _volume = GetComponent<Volume>();
        }

        protected override void OnTodChanged(AbstractTodData data)
        {
            _volume.priority = IsActive(data) ? 1 : 0;
        }
    }
}
