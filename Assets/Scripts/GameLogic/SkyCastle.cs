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
        void Start()
        {
            StartCoroutine(Tick());
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
    }
}