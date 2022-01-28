using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Creator.Player
{
    public class TowerPlacer : MonoBehaviour
    {
        private Vector3 towerPlacement; 
        
        private void FixedUpdate()
        {
            RaycastHit hit;
            // Does the ray intersect any objects excluding the player layer
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), out hit, Mathf.Infinity))
            {
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.down) * hit.distance, Color.yellow);
                Debug.Log("Did Hit");
                towerPlacement = hit.point; 
            }
            else
            {
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.down) * 1000, Color.white);
                Debug.Log("Did not Hit");
                towerPlacement = Vector3.zero;
            }
        }

        public Vector3 GetTowerPlacement() => this.towerPlacement;
    }
}
