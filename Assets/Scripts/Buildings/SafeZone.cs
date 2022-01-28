using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Creator.Buildings
{
    public class SafeZone : MonoBehaviour
    {
        [SerializeField] private WareHouse localWarehouse;
        [SerializeField] private List<Building> buildingsInTheArea;
        private void OnTriggerEnter(Collider other)
        { 
            var otherBuilding = other.gameObject.GetComponent<Building>();
            if(otherBuilding != null)
            {
                buildingsInTheArea.Add(otherBuilding);
            }
        }

        public List<Building> Buildings => buildingsInTheArea;
    }
}
