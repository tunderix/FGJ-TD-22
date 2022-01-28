using System.Collections;
using System.Collections.Generic;
using Creator.Utilities;
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
            D.Info("Warehouse Collecting");
            int buildingsToCollectFrom = 0;
            foreach (Building building in safeZone.Buildings)
            {
                var resourceGatherer = building.gameObject.GetComponent<ResourceGatherer>();
                if (resourceGatherer != null)
                {
                    var successfulCollection = resourceGatherer.Collect();
                    if (successfulCollection) buildingsToCollectFrom += 1;
                }
            }
            
            inventory.AddResources(AmountOfResource(buildingsToCollectFrom));
        }

        private int AmountOfResource(int buildingCount) => buildingCount * amountToCollect; 
    }
}
