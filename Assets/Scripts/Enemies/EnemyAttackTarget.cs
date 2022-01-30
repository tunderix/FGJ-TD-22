using System;
using System.Collections;
using System.Collections.Generic;
using Creator.Common.GameEvent;
using Creator.GameLogic;
using UnityEngine;

namespace Creator.Enemies
{
    public class EnemyAttackTarget : MonoBehaviour
    {
        [SerializeField] private int HP;
        [SerializeField] private SkyCastle skyCastle;
        public void TakeDamage()
        {
            HP--;
            if (HP <= 0)
            {
                skyCastle.OnEnemyTargetDead(this);
            }
        }
    }
}
