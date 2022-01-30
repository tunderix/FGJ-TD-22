using System;
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
        
        [SerializeField] private Building isGhostingBuilding;

        private void Awake()
        {
            isGhostingBuilding = null;
        }

        private void Building(BuildingData buildingData)
        {
            if (isGhostingBuilding == null)
            {
                var building = PlaceGhostBuilding(buildingData);
                building.TowerPlacer = placer;
                isGhostingBuilding = building; 
            }
            else if (isGhostingBuilding.Recipe.BuildingType == buildingData.BuildingType)
            {
                isGhostingBuilding.isCreated();
                PlaceRealBuilding(buildingData, isGhostingBuilding);
                isGhostingBuilding = null;
            }
            else
            {
                isGhostingBuilding = null;
            }
        }

        void OnPlaceWareHouse()
        {
            Building(warehouse);
        }

        void OnDeactivateSelection()
        {
            if(isGhostingBuilding != null)
            {
                isGhostingBuilding = null;
                Destroy(isGhostingBuilding.gameObject);
            }
        }

        void OnPlaceGatherStation()
        {
            Building(gatherStation);
        }
        
        void OnSwitchGameState()
        {
            skyCastle.ToggleState();
        }
        
        void OnPlaceProjectileTower()
        {
            Building(projectileTower);
        }

        private void PlaceRealBuilding(BuildingData buildingData, Building building)
        {
            var canBuild = buildingData.BuildingRecipe.CanBuild(inventory.Crystals, inventory.Wood);
            if (!canBuild) return;

            var successfullyBought = inventory.Buy(buildingData.BuildingRecipe);
            if (successfullyBought)
            {
                building.GhostPlacing(GhostBuildingMode.Real);
            }
        }

        private Building PlaceGhostBuilding(BuildingData buildingData)
        {
            GameObject ghostPrefab = Instantiate(buildingData.Prefab, placer.GetTowerPlacement(), Quaternion.identity);
            var ghostWarehouse = ghostPrefab.GetComponent<WareHouse>();
            if (ghostWarehouse != null)
            {
                ghostWarehouse.GhostPlacing(GhostBuildingMode.Ghost);
            }

            var building = ghostPrefab.GetComponent<Building>();
            return building != null ? building : null;
        }
    }
}
