using System;
using System.Collections;
using System.Collections.Generic;
using Creator.Enemies;
using UnityEngine;

namespace Creator.Buildings
{
    /// <summary>
    /// Tower
    /// Common Tower game object
    /// </summary>
    public class Tower : Building
    {
        [SerializeField] private EnemyObserver enemyObserver;
        [SerializeField] private Gun gun; 
        
        [SerializeField] private float shootingInterval;
        [SerializeField] private Enemy enemyToShootAt; 
        void Start()
        {
            enemyToShootAt = null; 
            StartCoroutine(Shoot());
        }

        private void Update()
        {
            if (enemyToShootAt == null)
            {
                enemyToShootAt = enemyObserver.RandomEnemy();
            }
            else
            {
                gun.LookAt(enemyToShootAt.Target);
            }
        }

        public void SetEnemy(Enemy e)
        {
            enemyToShootAt = e;
        }

        IEnumerator<WaitForSeconds> Shoot()
        {
            while (true)
            {
                yield return new WaitForSeconds(shootingInterval);
                if(enemyToShootAt != null) gun.Shoot(enemyToShootAt);
                enemyToShootAt = null;
            }

        }
    }
}
