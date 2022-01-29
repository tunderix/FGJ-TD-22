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
        void Start()
        {
            StartCoroutine(Shoot());
        }

        IEnumerator<WaitForSeconds> Shoot()
        {
            while (enemyObserver.EnemyAccessible)
            {
                yield return new WaitForSeconds(shootingInterval);
                gun.Shoot();
            }

        }
    }
}
