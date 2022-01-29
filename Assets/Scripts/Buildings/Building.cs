using System.Collections;
using System.Collections.Generic;
using Creator.ResourceManagement;
using UnityEngine;

namespace Creator.Buildings
{
    /// <summary>
    /// Building
    /// Base class for all buildings in game
    /// </summary>
    public class Building : MonoBehaviour
    {
        [SerializeField] private BuildingData data;

        public GameObject Prefab => data.Prefab; 
        public BuildingType BuildingType => data.BuildingType;

        public Recipe Recipe => data.BuildingRecipe;
    }
}
