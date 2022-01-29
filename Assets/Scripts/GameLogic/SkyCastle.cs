using System;
using System.Collections.Generic;
using Creator.Common.GameEvent;
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
        void Start()
        {
            gameStateDay.Invoke();
            StartCoroutine(Tick());
            StartCoroutine(ToggleGameState());
        }

        public void ToggleState()
        {
            gameStateIsDay = !gameStateIsDay;
            if(gameStateIsDay) gameStateDay.Invoke();
            else gameStateNight.Invoke();
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