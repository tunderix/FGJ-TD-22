using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Creator.Enemies
{
    public class EnemyObserver : MonoBehaviour
    {
        [SerializeField] private List<Enemy> enemiesInRange;
        
        public Enemy RandomEnemy()
        {
            //enemiesInRange[Random(enemiesInRange.Count)];
            return null;
        }
        private void OnTriggerEnter(Collider other)
        {
            var enemy = other.gameObject.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemiesInRange.Add(enemy);
            }
        }

        private void OnTriggerExit(Collider other)
        {
            var enemy = other.gameObject.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemiesInRange.Remove(enemy);
            }
        }

        public bool EnemyAccessible => enemiesInRange.Count > 0;
    }
}
