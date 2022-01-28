using System;
using System.Collections;
using System.Collections.Generic;
using Creator.ResourceManagement;
using UnityEngine;

namespace Creator.Buildings
{
    public class ResourceGatherer : Building
    {
        [SerializeField] private ResourceGatherArea gatherArea;
        public List<ResourceNode> ResourceNodesInArea => gatherArea.resourceNodesInArea;
    }
}
