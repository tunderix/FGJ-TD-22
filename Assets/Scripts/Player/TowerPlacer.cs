using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Creator.Player
{
    public class TowerPlacer : MonoBehaviour
    {
        private Vector3 towerPlacement; 
        [SerializeField] private LayerMask layerMask;
        
        private void FixedUpdate()
        {
            // layerMask = ~layerMask;
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), out hit, Mathf.Infinity, layerMask, QueryTriggerInteraction.Ignore))
            {
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.down) * hit.distance, Color.yellow);
            }
            else
            {
                //hit = Vector3.zero;
            }

            towerPlacement = hit.point; 
        }

        public Vector3 GetTowerPlacement() => this.towerPlacement;
    }
}
