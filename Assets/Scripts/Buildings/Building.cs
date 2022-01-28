using System.Collections;
using System.Collections.Generic;
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
    }
}
