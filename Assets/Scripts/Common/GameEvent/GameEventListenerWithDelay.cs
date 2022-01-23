using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace Common.GameEvent
{
    public class GameEventListenerWithDelay : GameEventListener
    {
        [SerializeField] private float delay = 1f; 
        [SerializeField] private UnityEvent delayedUnityEvent;

        private void Awake() => gameEvent.Register(this);
        private void OnDestroy() => gameEvent.Deregister(this);
        
        public override void RaiseEvent()
        {
            unityEvent.Invoke();
            if(debuggingEnabled) Debug.Log("Unity event was triggered");
            StartCoroutine(RunDelayedEvent());
        }

        private IEnumerator RunDelayedEvent()
        {
            yield return new WaitForSeconds(delay);
            delayedUnityEvent.Invoke();
        }
    }
}
