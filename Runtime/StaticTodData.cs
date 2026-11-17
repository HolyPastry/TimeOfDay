using System;
using System.Collections.Generic;
using System.Linq;
using Codice.CM.Common.Matcher;
using UnityEngine;

namespace Bakery
{
    public abstract class AbstractTodData : ScriptableObject
    {
        [Header("Parameters")]
        public List<TODFilter> _filters;

        public abstract void Record();

        public abstract void Apply();

        internal bool CheckAllFilters(List<TODFilter> filters)
        {
            return filters.TrueForAll(f => _filters.Contains(f));
        }
    }
}
