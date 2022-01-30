using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Creator.Player;
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
        [SerializeField] private GhostBuildingMode PlacingBuildingGhost;
        [SerializeField] private MeshRenderer renderer;
        [SerializeField] private Material ghostMaterial; 
        [SerializeField] private Material realMaterial;
        private TowerPlacer placer;

        public GameObject Prefab => data.Prefab; 
        public BuildingType BuildingType => data.BuildingType;

        public Recipe Recipe => data.BuildingRecipe;

        public TowerPlacer TowerPlacer
        {
            get => placer;
            set
            {
                placer = value;
                
            }
        }

        private void Update()
        {
            if (PlacingBuildingGhost != GhostBuildingMode.Ghost) return;
                
            gameObject.transform.SetPositionAndRotation(TowerPlacer.GetTowerPlacement(), TowerPlacer.transform.rotation);
        }

        /// <summary>
        /// Updates the position of the ghost building while we are building
        /// </summary>
        /// <param name="position">Vector3 containing the position</param>
        /// <param name="quaternion">Rotation of the ghost building</param>
        public void SetGhostPosition(Vector3 position, Quaternion quaternion)
        {
            gameObject.transform.SetPositionAndRotation(position, quaternion);
        }

        public void GhostPlacing(GhostBuildingMode mode)
        {
            PlacingBuildingGhost = mode;
            if (renderer == null) return; 
            
            var newMaterials = new List<Material>();
            if (mode == GhostBuildingMode.Empty)
            {
                renderer.materials = newMaterials.ToArray();
                return; 
            }
            
            if (mode == GhostBuildingMode.Ghost)
            {
                newMaterials.Add(ghostMaterial);
            }
            
            if (mode == GhostBuildingMode.Real)
            {
                newMaterials.Add(realMaterial);
            }

            renderer.materials = newMaterials.ToArray();
        }
    }
}
