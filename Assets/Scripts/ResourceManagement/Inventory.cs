using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Creator.UI;
using TMPro;
using UnityEngine;

namespace Creator.ResourceManagement
{
    public class Inventory : MonoBehaviour
    {
        [SerializeField] private int crystals;
        [SerializeField] private int wood; 
  
        [SerializeField] private TextMeshProUGUI resourceLabelCrystal;
        [SerializeField] private TextMeshProUGUI resourceLabelWood;
        [SerializeField] private ActionButton projectileTowerButton;
        [SerializeField] private ActionButton gathererButton;
        [SerializeField] private ActionButton warehouseButton;
        [SerializeField] private Recipe gathererRecipe;
        [SerializeField] private Recipe towerRecipe; 
        [SerializeField] private Recipe warehouseRecipe;  
        public int Crystals => crystals;
        public int Wood => wood; 
        
        public void AddResources(ResourceType resourceType, int amount)
        {
            if (resourceType == ResourceType.Crystal)
            {
                crystals += amount;
            }
            if (resourceType == ResourceType.Wood)
            {
                wood += amount;
            }
            updateUIResources();
        }
        
        public void RemoveResources(ResourceType resourceType, int amount)
        {
            if (resourceType == ResourceType.Crystal)
            {
                crystals -= amount;
            }
            if (resourceType == ResourceType.Wood)
            {
                wood -= amount;
            }
            updateUIResources();
        }

        private void updateUIResources()
        {
            // Update resource labels
            resourceLabelCrystal.SetText(crystals.ToString());
            resourceLabelWood.SetText(wood.ToString());
            
            projectileTowerButton.UpdateContents(towerRecipe.CanBuild(crystals, wood));
            warehouseButton.UpdateContents(warehouseRecipe.CanBuild(crystals, wood));
            gathererButton.UpdateContents(gathererRecipe.CanBuild(crystals, wood));
        }

        public bool ResourceTypeEnough(ResourceTypeRequirement resourceTypeRequirement)
        {
            if (resourceTypeRequirement.ResourceType == ResourceType.Crystal
                && crystals < resourceTypeRequirement.ResourceRequirement)
            {
                return false;
            }
            if (resourceTypeRequirement.ResourceType == ResourceType.Wood
                && wood < resourceTypeRequirement.ResourceRequirement)
            {
                return false;
            }

            return true;
        }

        public bool Buy(Recipe buildingRecipe)
        {
            bool playerHasEnough = buildingRecipe.ResourcesNeeded.All(resourceTypeRequirement => ResourceTypeEnough(resourceTypeRequirement));
            if (playerHasEnough)
            {
                buildingRecipe.ResourcesNeeded.ForEach(resourceTypeRequirement => 
                    RemoveResources(resourceTypeRequirement.ResourceType, resourceTypeRequirement.ResourceRequirement));
            }
            return playerHasEnough;
        }
    }
}
