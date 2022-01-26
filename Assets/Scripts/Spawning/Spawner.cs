using System.Collections.Generic;
using System.Linq;
using Creator.Utilities;
using UnityEngine;

namespace Creator.Spawning
{
    /// <summary>
    /// A spawner game object used to spawn different kind of spawnable objects. 
    /// </summary>
    public class Spawner : MonoBehaviour
    {
        [SerializeField] private List<SpawnableObject> spawnables;
        [OverrideLabelAttribute( "Size of the spawn queue" )] [SerializeField] private int spawnQueueSize; 
        [SerializeField] private List<SpawnableObject> spawningQueue;

        private Collider _collider;
        
        private void Awake()
        {
            _collider = this.gameObject.GetComponent<Collider>();
        }

        /// <summary>
        /// Generate a queue of random SpawnableObjects based on possible spawnables
        /// </summary>
        public void GenerateQueue()
        {
            spawningQueue ??= new List<SpawnableObject>(spawnQueueSize);

            for (var i = 0; i < spawnQueueSize; i++)
            {
                var newSpawnable =
                    ScriptableObject.CreateInstance<SpawnableObject>();
                var randomSpawnable = RandomSpawnable;
                newSpawnable.Set(randomSpawnable);
                spawningQueue.Add(randomSpawnable);
            }
        }

        /// <summary>
        /// Spawn first object from the queue and then remove the object from the queue
        /// </summary>
        public void SpawnObject()
        {
            if (spawningQueue.Count < 1) return;

            var objectToRemove = spawningQueue.First(); 
            spawningQueue.Remove(objectToRemove);
            SpawnObject(objectToRemove);
        }

        private SpawnableObject RandomSpawnable => spawnables[Random.Range(0, spawnables.Count)];

        private void SpawnObject(SpawnableObject spawnable)
        {
            var randomPoint = TransformUtilities.RandomPointInside(_collider);
            var newSpawnableGameObject = Instantiate(spawnable.GetSpawnable(), randomPoint, Quaternion.identity);
            if (newSpawnableGameObject != null)
            {
                newSpawnableGameObject.OnSpawn(randomPoint);
            }
        }

        private void OnDrawGizmos()
        {
            var t = this.transform;
            Gizmos.DrawWireCube(t.position, t.localScale);
        }
    }
}
