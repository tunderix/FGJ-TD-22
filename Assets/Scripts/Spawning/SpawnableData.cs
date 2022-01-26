using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Creator.Spawning
{
    /// <summary>
    /// Data Model for Spawnable
    /// </summary>
    [System.Serializable]
    public class SpawnableData
    {
        /// <summary>
        /// Setter for name
        /// </summary>
        /// <param name="name">New name for spawnable</param>
        public void SetName(string name)
        {
            Name = name; 
        }

        /// <summary>
        /// Name of the Spawnable
        /// </summary>
        public string Name { get; private set; }
    }
}
