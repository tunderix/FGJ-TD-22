using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Creator.ResourceManagement
{
    public class Inventory : MonoBehaviour
    {
        [SerializeField] private int resources;
        [SerializeField] private TextMeshProUGUI resourceLabel; 
        public void AddResources(int amount)
        {
            resources += amount;
            updateUIResources();
        }

        public void RemoveResources(int amount)
        {
            resources -= amount;
            updateUIResources();
        }

        private void updateUIResources()
        {
            resourceLabel.SetText(resources.ToString());
        }
    }
}
