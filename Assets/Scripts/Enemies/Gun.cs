using System;
using UnityEngine;
using UnityEngine.PlayerLoop;

namespace Creator.Enemies
{
    public class Gun : MonoBehaviour
    {
        [SerializeField] private GameObject bulletPrefab;
        

        public void Shoot(Enemy at)
        {
            if (at == null) return;
            var bulletObject = Instantiate(bulletPrefab, transform.position, transform.rotation, transform);
        }

        public void LookAt(Transform t)
        {
            Debug.DrawRay(this.transform.position, t.position, Color.red, 5.0f);
            transform.LookAt(t);
        }
    }
}
