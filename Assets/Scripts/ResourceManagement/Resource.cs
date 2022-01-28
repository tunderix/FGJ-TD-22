using UnityEngine;

namespace Creator.ResourceManagement
{
    [CreateAssetMenu(menuName = "Resource", fileName = "New Resource")]
    public class Resource : ScriptableObject
    {
        [SerializeField] private ResourceType resourceType;
        [SerializeField] private string resourceName;
        [SerializeField] private int resourceValue;

        public ResourceType ResourceType => resourceType;
        public int ResourceValue => resourceValue; 
    }
}
