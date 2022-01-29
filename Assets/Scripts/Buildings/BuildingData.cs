using System.Collections.Generic;
using Creator.ResourceManagement;
using UnityEngine;

namespace Creator.Buildings
{
    [CreateAssetMenu(menuName = "Building", fileName = "New Building")]
    public class BuildingData : ScriptableObject
    {
        [SerializeField] private BuildingType _buildingType;
        [SerializeField] private string _buildingName;
        [SerializeField] private Recipe buildingRecipe; 
        [SerializeField] private GameObject prefabObject;

        public GameObject Prefab => prefabObject;
        public BuildingType BuildingType => _buildingType;

        public Recipe BuildingRecipe => buildingRecipe; 
    }
}