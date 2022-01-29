using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Creator.Enemies
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private int HP;
        [SerializeField] private Transform shootingTarget; 
        
        public void TakeDamage()
        {
            HP--;
            if (HP <= 0)
            {
                Destroy(this.gameObject);
            }
        }

        public Vector3 TargetPosition => shootingTarget.position; 
        public Transform Target => shootingTarget; 
        
        private void OnTriggerEnter(Collider other)
        {
            var bullet = other.GetComponent<Bullet>();
            if (bullet != null)
            {
                TakeDamage();
                Destroy(bullet.gameObject);
            }
        }
    }
}
