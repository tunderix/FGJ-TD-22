using Creator.Buildings;
using Creator.GameLogic;
using Creator.ResourceManagement;
using UnityEngine;

namespace Creator.Player
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private TowerPlacer placer;

        [SerializeField] private BuildingData projectileTower;
        [SerializeField] private BuildingData warehouse;
        [SerializeField] private BuildingData gatherStation;

        [SerializeField] private Inventory inventory;
        [SerializeField] private SkyCastle skyCastle;
        void OnPlaceWareHouse()
        {
            var canBuild = warehouse.BuildingRecipe.CanBuild(inventory.Crystals, inventory.Wood);
            if (!canBuild) return;

            var successfullyBought = inventory.Buy(warehouse.BuildingRecipe);
            if (successfullyBought)
            {
                GameObject newGo = Instantiate(warehouse.Prefab, placer.GetTowerPlacement(), Quaternion.identity);
                var newWarehouse = newGo.GetComponent<WareHouse>();
                if (newWarehouse != null)
                {
                    skyCastle.RegisterWarehouse(newWarehouse);
                }
            }
        }

        void OnPlaceGatherStation()
        {
            var canBuild = gatherStation.BuildingRecipe.CanBuild(inventory.Crystals, inventory.Wood);
            if (!canBuild) return;

            var successfullyBought = inventory.Buy(gatherStation.BuildingRecipe);
            if (successfullyBought)
            {
                GameObject.Instantiate(gatherStation.Prefab, placer.GetTowerPlacement(), Quaternion.identity);
            }
        }
        
        void OnSwitchGameState()
        {
            skyCastle.ToggleState();
        }
        
        void OnPlaceProjectileTower()
        {
            var canBuild = projectileTower.BuildingRecipe.CanBuild(inventory.Crystals, inventory.Wood);
            if (!canBuild) return;

            var successfullyBought = inventory.Buy(projectileTower.BuildingRecipe);
            if (successfullyBought)
            {
                GameObject.Instantiate(projectileTower.Prefab, placer.GetTowerPlacement(), Quaternion.identity);
            }
        }
    }
}
