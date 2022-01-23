using UnityEngine;
using UnityEngine.Events;

namespace Common.GameEvent
{
    public class GameEventListener : MonoBehaviour
    {
        [SerializeField] public GameEvent gameEvent;
        [SerializeField] public UnityEvent unityEvent;
        [SerializeField] public bool debuggingEnabled;

        private void Awake() => RegisterGameEvent(this);
        private void OnDestroy() => DeregisterGameEvent(this);
        
        public void RegisterGameEvent(GameEventListener listener)
        {
            if (gameEvent == null) return;
            
            if(debuggingEnabled) Debug.Log("GameEventListener was registered");
            gameEvent.Register(listener);
        }
        
        public void DeregisterGameEvent(GameEventListener listener)
        {
            if (gameEvent == null) return;
            
            if(debuggingEnabled) Debug.Log("GameEventListener was Deregistered");
            gameEvent.Deregister(listener);
        }
        
        public virtual void RaiseEvent() {
            if(debuggingEnabled) Debug.Log("Unity Event was triggered");
            unityEvent.Invoke();
        }
    }
}
