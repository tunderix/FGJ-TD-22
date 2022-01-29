using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Creator.Enemies
{
    public class AttackArea : MonoBehaviour
    {
        [SerializeField] private Enemy enemy;
        private void OnTriggerEnter(Collider other)
        {
            var attackTarget = other.GetComponent<EnemyAttackTarget>();
            if (attackTarget != null)
            {
                attackTarget.TakeDamage();
                enemy.AttackTrigger();
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.GetComponent<EnemyAttackTarget>())
            {
                enemy.AttackStopped();
            }
        }

        private void OnCollisionEnter(Collision collision)
        {
            var attackTarget = collision.collider.GetComponent<EnemyAttackTarget>();
            if (attackTarget != null)
            {
                attackTarget.TakeDamage();
                enemy.AttackTrigger();
            }
        }
    }
}
