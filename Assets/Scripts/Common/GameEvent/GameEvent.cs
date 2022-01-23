using System.Collections.Generic;
using UnityEngine;

namespace Common.GameEvent
{
    [CreateAssetMenu(menuName = "Game Event", fileName = "New Game Event")]
    public class GameEvent : ScriptableObject
    {
        private readonly HashSet<GameEventListener> _listeners = new HashSet<GameEventListener>();
        
        public void Invoke()
        {
            foreach (var globalEventListener in _listeners)
            {
                globalEventListener.RaiseEvent();
            }
        }

        public int ListenerCount => _listeners.Count;

        public void Register(GameEventListener geListener) => _listeners.Add(geListener);

        public void Deregister(GameEventListener geListener) => _listeners.Remove(geListener);
    }
}