using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Creator.Enemies
{
    public class Bullet : MonoBehaviour
    {
        public Enemy TargetEnemy;

        private void Awake()
        {
            TargetEnemy = null; 
        }

        void Update()
        {
            if (TargetEnemy != null)
            {
                
            }
        }
    }
}
