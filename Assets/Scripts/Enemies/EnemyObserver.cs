using System.Collections;
using System.Collections.Generic;
using Creator.Buildings;
using UnityEngine;

namespace Creator.Enemies
{
    public class EnemyObserver : MonoBehaviour
    {
        [SerializeField] private List<Enemy> enemiesInRange;

        public Enemy RandomEnemy()
        {
            if (enemiesInRange.Count < 1) return null; 
            return enemiesInRange[Random.Range(0, enemiesInRange.Count-1)];
        }
        private void OnTriggerEnter(Collider other)
        {
            var enemy = other.gameObject.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemiesInRange.Add(enemy);
                var thisTower = this.gameObject.GetComponentInParent<Tower>();
                if(thisTower != null) thisTower.SetEnemy(enemy);
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
