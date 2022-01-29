using System;
using System.Collections;
using System.Collections.Generic;
using Creator.Buildings;
using UnityEngine;
using System.Linq;
using UnityEngine.AI;

namespace Creator.Enemies
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private int HP;
        [SerializeField] private Transform shootingTarget;
        [SerializeField] private GameObject navigationTarget;
        private NavMeshAgent _navMeshAgent;

        private void Start()
        {
            _navMeshAgent = this.GetComponent<NavMeshAgent>();
            SetNavigationTarget(FindClosestWarehouse());
        }

        private GameObject FindClosestWarehouse()
        {
            var Warehouses = GameObject.FindGameObjectsWithTag("Warehouse");
            GameObject chosenWarehouse = null;
            var highestDistance = 0f; 
            foreach (var warehouse in Warehouses)
            {
                var distanceToWarehouse = Vector3.Distance(transform.position, warehouse.transform.position);
                if (distanceToWarehouse > highestDistance)
                {
                    chosenWarehouse = warehouse;
                }
            }
            return chosenWarehouse; 
        }

        public void SetNavigationTarget(GameObject go)
        {
            navigationTarget = go;
            _navMeshAgent.SetDestination(navigationTarget.transform.position);
        }

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
