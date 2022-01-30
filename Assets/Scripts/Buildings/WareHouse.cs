using System;
using System.Collections.Generic;
using Creator.ResourceManagement;
using UnityEngine;

namespace Creator.Buildings
{
    /// <summary>
    /// WareHouse
    /// Common warehouse script
    /// </summary>
    public class WareHouse : Building
    {
        [SerializeField] private SafeZone safeZone;
        [SerializeField] private Inventory inventory;
        [SerializeField] private int amountToCollect; 
        public void Collect()
        {
            List<ResourceNode> resourceNodesToCollect = null;
            foreach (Building building in safeZone.Buildings)
            {
                var resourceGatherer = building.gameObject.GetComponent<ResourceGatherer>();
                if (building.BuildingType == BuildingType.Gatherer && resourceGatherer != null)
                {
                    resourceNodesToCollect = resourceGatherer.ResourceNodesInArea;
                }
            }

            if (resourceNodesToCollect == null) return; 
            foreach (var resourceNode in resourceNodesToCollect)
            {
                inventory.AddResources(resourceNode.ResourceType, resourceNode.Value);
            }
        }

        public void SetInventory(Inventory _inventory)
        {
            inventory = _inventory;
        }

        private int AmountOfResource(int buildingCount) => buildingCount * amountToCollect;

        public override void isCreated()
        {
            var go = GameObject.FindWithTag("Inventory");
            var _inventory = go.GetComponent<Inventory>();
            if (_inventory != null)
            {
                inventory = _inventory;
            }
        }
    }
}
