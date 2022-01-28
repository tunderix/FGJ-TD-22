using System.Collections.Generic;
using UnityEngine;

namespace Creator.Buildings
{
    [CreateAssetMenu(menuName = "Building", fileName = "New Building")]
    public class BuildingData : ScriptableObject
    {
        [SerializeField] private BuildingType _buildingType;
        [SerializeField] private string _buildingName;
    }
}