using System.Collections.Generic;
using System.Linq;
using Bakery.Core;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace Bakery
{
    public partial class StaticTodController : MonoBehaviour, IToDController
    {
        [SerializeField]
        private string _resourcePath = "";

        [SerializeField]
        private AbstractTodData _todData;

        private DataCollection<AbstractTodData> _collection;

        void Awake()
        {
            _collection = new(_resourcePath);
        }

        void OnEnable()
        {
            TOD.Controller = () => this;
        }

        void OnDisable()
        {
            TOD.Controller = TOD.UnregisterController;
        }

        [ContextMenu("Update TOD")]
        private void UpdateSettings()
        {
            ApplySettings(_todData);
        }

        private void ApplySettings(AbstractTodData todData)
        {
            todData.Apply();
        }

#if UNITY_EDITOR
        [ContextMenu("Record Settings")]
        private void RecordSettings()
        {
            _todData.Record();

            EditorUtility.SetDirty(_todData);
            AssetDatabase.Refresh();
            AssetDatabase.SaveAssetIfDirty(_todData);
        }
#endif

        public void Set(List<TODFilter> filters)
        {
            var sortedCollection = _collection
                .Data.Where(tod =>
                {
                    foreach (var filter in filters)
                        if (filter.IsMandatory && !tod._filters.Contains(filter))
                            return false;

                    return true;
                })
                .OrderBy(tod => filters.Count(f => tod._filters.Contains(f)));

            if (sortedCollection.Count() == 0)
                Debug.LogWarning("No Matching TOD parameters found");

            var tod = sortedCollection.ElementAt(0);
            ApplySettings(tod);
            TOD.Events.OnChanged(tod);
        }
    }
}
