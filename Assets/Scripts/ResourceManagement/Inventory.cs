using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Creator.ResourceManagement
{
    public class Inventory : MonoBehaviour
    {
        [SerializeField] private int resources;

        public void AddResources(int amount)
        {
            resources += amount;
        }

        public void RemoveResources(int amount)
        {
            resources -= amount; 
        }
    }
}
