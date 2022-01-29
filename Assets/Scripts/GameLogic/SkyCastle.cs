using System;
using System.Collections.Generic;
using Creator.Buildings;
using Creator.Common.GameEvent;
using Creator.Enemies;
using Creator.Player;
using Creator.Utilities;
using UnityEngine;

namespace Creator.GameLogic
{
    /// <summary>
    /// Game Manager object
    /// </summary>
    public class SkyCastle : MonoBehaviour
    {
        [SerializeField] private float gameTimerInterval; 
        [SerializeField] private GameEvent collectResources;
        [SerializeField] private int minutes; 
        [SerializeField] private GameEvent gameStateDay;
        [SerializeField] private GameEvent gameStateNight;
        public bool gameStateIsDay = true;
        [SerializeField] private GameEvent gameOver;

        [SerializeField] private List<WareHouse> warehouses;
        void Start()
        {
            gameStateDay.Invoke();
            StartCoroutine(Tick());
            StartCoroutine(ToggleGameState());
        }

        public void RegisterWarehouse(WareHouse warehouse)
        {
            warehouses.Add(warehouse);
        }

        public void OnEnemyTargetDead(EnemyAttackTarget eat)
        {
            if (eat.gameObject.GetComponent<PlayerController>())
            {
                gameOver.Invoke();
            }

            var warehouse = eat.gameObject.GetComponent<WareHouse>();
            if (warehouse != null)
            {
                warehouses.Remove(warehouse); 
            }

            if (warehouses.Count <= 0)
            {
                gameOver.Invoke();
            }
        }
        
        public void ToggleState()
        {
            gameStateIsDay = !gameStateIsDay;
            if(gameStateIsDay) gameStateDay.Invoke();
            else gameStateNight.Invoke();
            D.Info("Changed game to ", gameStateIsDay? "day" : "night");
        }
        

        private void ResourceCollection()
        {
            D.Info("Resource Collection");
            collectResources.Invoke();
        }
        
        IEnumerator<WaitForSeconds> Tick()
        {
            while (true)
            {
                yield return new WaitForSeconds(gameTimerInterval);
                ResourceCollection();
            }

        }
        
        IEnumerator<WaitForSeconds> ToggleGameState()
        {
            while (true)
            {
                yield return new WaitForSeconds(minutes * 60);
                ToggleState();
            }

        }
    }
}