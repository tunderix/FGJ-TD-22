using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

namespace Creator.Common.GameEvent
{
    public class GameEventListener : MonoBehaviour
    {
        [FormerlySerializedAs("triggerEvent")] [SerializeField] public GameEvent listenEvent;
        [FormerlySerializedAs("unityEvent")] [SerializeField] public UnityEvent actEvent;
        [SerializeField] public bool debuggingEnabled;

        private void Awake() => RegisterGameEvent(this);
        private void OnDestroy() => DeregisterGameEvent(this);
        
        public void RegisterGameEvent(GameEventListener listener)
        {
            if (listenEvent == null) return;
            if(debuggingEnabled) Debug.Log("GameEventListener was registered");
            listenEvent.Register(listener);
        }
        
        public void DeregisterGameEvent(GameEventListener listener)
        {
            if (listenEvent == null) return;
            if(debuggingEnabled) Debug.Log("GameEventListener was Deregistered");
            listenEvent.Deregister(listener);
        }
        
        public virtual void RaiseEvent() {
            if(debuggingEnabled) Debug.Log("Unity Event was triggered");
            actEvent.Invoke();
        }
    }
}
