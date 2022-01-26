using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Creator.Spawning
{
    /// <summary>
    /// The scriptable object for registering new spawnable objects to be used in spawner. 
    /// </summary>
    [System.Serializable]
    [CreateAssetMenu(fileName = "Spawnable", menuName = "Spawns/SpawnableObject")]
    public class SpawnableObject: ScriptableObject
    {
        [SerializeField] private new string name;
        [SerializeField] private Spawnable spawnable;

        /// <summary>
        /// Set content of SpawnableObject based on other spawnable object.
        /// </summary>
        /// <param name="spawnableObject">Other same kind of SpawnableObject</param>
        public void Set(SpawnableObject spawnableObject)
        {
            this.name = spawnableObject.name;
            this.spawnable = spawnableObject.spawnable;
        }

        /// <summary>
        /// Accessor for Spawnable
        /// </summary>
        /// <returns>Spawnable</returns>
        public Spawnable GetSpawnable()
        {
            return spawnable;
        }
    }
}
