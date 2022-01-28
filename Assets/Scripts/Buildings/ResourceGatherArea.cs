using System;
using System.Collections;
using System.Collections.Generic;
using Creator.ResourceManagement;
using UnityEngine;

namespace Creator.Buildings
{
    public class ResourceGatherArea : MonoBehaviour
    {
        public List<ResourceNode> resourceNodesInArea; 
        private void OnTriggerEnter(Collider other)
        {
            var resourceNode = other.gameObject.GetComponent<ResourceNode>();
            if (resourceNode != null)
            {
                resourceNodesInArea.Add(resourceNode);
            }
        }
    }
}
