using System;
using Creator.Common.GameEvent;
using UnityEngine;

namespace Creator.GameLogic
{
    /// <summary>
    /// Game Manager object
    /// </summary>
    public class SkyCastle : MonoBehaviour
    {
        [SerializeField] private GameEvent gameStarted; 
        private void Awake()
        {
            
        }

        void Start()
        {
            gameStarted.Invoke();
        }

        void Update()
        {
        
        }
    }
}