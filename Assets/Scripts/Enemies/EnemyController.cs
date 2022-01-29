using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Creator.Common.GameEvent;
using Unity.VisualScripting;
using UnityEngine;

namespace Creator.Enemies
{
    public class EnemyController : MonoBehaviour
    {
        [SerializeField] private List<Enemy> allEnemies;
        [SerializeField] private GameEvent gameWon;

        private void Start()
        {
            var enemies = GetComponentsInChildren<Enemy>();
            allEnemies = enemies.ToList();
        }

        public void Remove(Enemy e)
        {
            allEnemies.Remove(e);
            CheckVictory();
        }

        public void CheckVictory()
        {
            if (allEnemies.Count <= 1)
            {
                gameWon.Invoke();
            }
        }
    }
}
