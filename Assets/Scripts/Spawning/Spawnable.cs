using Creator.Utilities;
using UnityEngine;

namespace Creator.Spawning
{
    /// <summary>
    /// Spawnable objects can be added to spawner, which then spawns these spawnables.
    /// Spawnable contains two attributes, the data and the game object reference.s
    /// </summary>
    public class Spawnable : MonoBehaviour, ISpawnable
    {
        [SerializeField] private SpawnableData data;
        [SerializeField] private Spawnable spawnable;
        [OverrideLabelAttribute("Debugging Active")] [SerializeField] private bool debug; 
        
        /// <summary>
        ///  Accessor for data determined in Unity UI
        /// </summary>
        /// <returns>Spawnable Data</returns>
        public SpawnableData GetSpawnableData()
        {
            return data;
        }

        /// <summary>
        /// Accessor for Spawnable
        /// </summary>
        /// <returns>Spawnable</returns>
        public Spawnable GetSpawnable()
        {
            return spawnable;
        }

        /// <summary>
        /// Triggered when this spawnable is actually spawned through some spawner. 
        /// </summary>
        /// <param name="positionToSpawn">3D location where the object should be spawn to</param>
        public void OnSpawn(Vector3 positionToSpawn)
        {
            if (debug)
            {
                Debug.Log("I was spawned" + positionToSpawn);
            }
        }
    }
}
