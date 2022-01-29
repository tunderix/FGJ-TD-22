using UnityEngine;

namespace Creator.Enemies
{
    public class Gun : MonoBehaviour
    {
        [SerializeField] private GameObject bulletPrefab;
        [SerializeField] private EnemyObserver enemyObserver;

        public void Shoot()
        {
            var bulletObject = GameObject.Instantiate(bulletPrefab, this.transform.position, Quaternion.identity);
            var newBullet = bulletObject.GetComponent<Bullet>();
            if (newBullet != null)
            {
                newBullet.TargetEnemy = enemyObserver.RandomEnemy();
            }
        }
    }
}
