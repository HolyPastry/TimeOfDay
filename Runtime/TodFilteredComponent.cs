using System.Collections.Generic;
using UnityEngine;

namespace Bakery
{
    public abstract class TodFilteredComponent : MonoBehaviour
    {
        [SerializeField]
        private List<TODFilter> _filters;

        protected virtual bool IsActive(AbstractTodData tod)
        {
            return tod.CheckAllFilters(_filters);
        }

        protected virtual void OnEnable()
        {
            TOD.Events.OnChanged += OnTodChanged;
        }

        protected virtual void OnDisable()
        {
            TOD.Events.OnChanged -= OnTodChanged;
        }

        protected abstract void OnTodChanged(AbstractTodData data);
    }
}
