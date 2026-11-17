using System.Collections.Generic;
using UnityEngine;

namespace Bakery
{
    public class GameObjectTODController : TodFilteredComponent
    {
        [SerializeField]
        private List<GameObject> _gameObjects;

        protected override void OnTodChanged(AbstractTodData data)
        {
            foreach (var go in _gameObjects)
            {
                go.SetActive(IsActive(data));
            }
        }
    }
}
