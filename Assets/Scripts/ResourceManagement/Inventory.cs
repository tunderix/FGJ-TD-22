using System.Collections;
using System.Collections.Generic;
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
        [SerializeField] private List<ActionButton> actionButtons;

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
            
            // Update Actionbuttons
            foreach (var actionButton in actionButtons)
            {
                actionButton.UpdateContents(crystals, wood);
            }
        }
    }
}
