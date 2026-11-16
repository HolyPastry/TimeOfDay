using System.Collections;
using Bakery.Flow;
using UnityEngine;

namespace Bakery
{
    public class SceneSetup_TimeOfDay : SceneSetupScript
    {
        [SerializeField]
        private Season _season;

        [SerializeField]
        private PeriodOfDay _periodOfDay;

        [SerializeField]
        private Weather _weather;

        public override IEnumerator Routine()
        {
            TOD.Controller().Set(_season, _periodOfDay, _weather);
            yield return null;
        }
    }
}
