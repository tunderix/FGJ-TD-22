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
            var isEnoughCrystals = false; 
            var isEnoughWood = false; 
            foreach (var buildingTypeRequirement in buildingResourceDemand)
            {
                if (buildingTypeRequirement.ResourceType == ResourceType.Crystal)
                {
                    isEnoughCrystals = buildingTypeRequirement.isEnough(crystals);
                }
                if (buildingTypeRequirement.ResourceType == ResourceType.Wood)
                {
                    isEnoughWood = buildingTypeRequirement.isEnough(woods);
                }
            }
            return isEnoughCrystals && isEnoughWood;
        }
    }
}
