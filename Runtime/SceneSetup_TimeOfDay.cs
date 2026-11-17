using System.Collections;
using System.Collections.Generic;
using Bakery.Flow;
using UnityEngine;

namespace Bakery
{
    public class SceneSetup_TimeOfDay : SceneSetupScript
    {
        [SerializeField]
        private List<TODFilter> _filters;

        public override IEnumerator Routine()
        {
            TOD.Controller().Set(_filters);
            yield return null;
        }
    }
}
