using UnityEngine;

namespace Bakery
{
    [CreateAssetMenu(fileName = "TodFilter", menuName = "Bakery/TOD/Filter")]
    public class TODFilter : ScriptableObject
    {
        [SerializeField]
        private bool _isMandatory;
        public bool IsMandatory => _isMandatory;
    }
}
