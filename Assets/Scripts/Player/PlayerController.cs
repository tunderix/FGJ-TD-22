using UnityEngine;

namespace Creator.Player
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private TowerPlacer placer;

        [SerializeField] private GameObject towerPrefab;

        void OnPlaceTower()
        {
            GameObject.Instantiate(towerPrefab, placer.GetTowerPlacement(), Quaternion.identity);
        }
    }
}
