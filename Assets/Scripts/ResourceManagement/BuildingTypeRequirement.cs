using System;
using Creator.Buildings;
using UnityEngine;

namespace Creator.ResourceManagement
{
    [Serializable]
    public class BuildingTypeRequirement
    {
        [SerializeField] private ResourceType type;
        [SerializeField] private int resourcesNeeded;

        public ResourceType ResourceType => type;
        public int ResourceRequirement => resourcesNeeded;

        public bool isEnough(int value)
        {
            return value >= resourcesNeeded;
        }
    }
}
