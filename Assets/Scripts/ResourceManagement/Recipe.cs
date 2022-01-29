using System.Collections;
using System.Collections.Generic;
using Creator.Buildings;
using UnityEngine;

namespace Creator.ResourceManagement
{
    [CreateAssetMenu(menuName = "Recipe", fileName = "New Recipe")]
    public class Recipe : ScriptableObject
    {
        [SerializeField] private BuildingType buildingType;
        [SerializeField] private List<ResourceTypeRequirement> buildingResourceDemand;

        public BuildingType BuildingType => buildingType;
        public List<ResourceTypeRequirement> ResourcesNeeded => buildingResourceDemand;

        public bool CanBuild(int crystals, int woods)
        {
            bool canBuild = false;
            foreach (var buildingTypeRequirement in buildingResourceDemand)
            {
                canBuild = false;
                canBuild = buildingTypeRequirement.ResourceType == ResourceType.Crystal &&
                           buildingTypeRequirement.isEnough(crystals);
                canBuild = buildingTypeRequirement.ResourceType == ResourceType.Wood &&
                           buildingTypeRequirement.isEnough(woods);
                if (canBuild) return true; 
            }
            return canBuild;
        }
    }
}
