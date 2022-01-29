using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Creator.Enemies
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private float speed = 3;
        
        private void Update()
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
        }

        private void OnTriggerEnter(Collider other)
        {
            var enemy = other.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.TakeDamage();
                Destroy(this.gameObject);
            }
        }

        private void OnTriggerExit(Collider other)
        {
            var enemyObserverExit = other.gameObject.GetComponent<EnemyObserver>();
            if (enemyObserverExit != null)
            {
                Destroy(this.gameObject);
            } 
        }
    }
}
