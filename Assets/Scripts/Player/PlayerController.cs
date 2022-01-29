using UnityEngine;

namespace Creator.Player
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private TowerPlacer placer;

        [SerializeField] private GameObject projectileTowerPrefab;
        [SerializeField] private GameObject warehousePrefab;
        [SerializeField] private GameObject gatherStationPrefab;

        void OnPlaceWareHouse()
        {
            GameObject.Instantiate(warehousePrefab, placer.GetTowerPlacement(), Quaternion.identity);
        }
        
        void OnPlaceGatherStation()
        {
            GameObject.Instantiate(gatherStationPrefab, placer.GetTowerPlacement(), Quaternion.identity);
        }
        
        void OnPlaceProjectileTower()
        {
            GameObject.Instantiate(projectileTowerPrefab, placer.GetTowerPlacement(), Quaternion.identity);
        }
    }
}
