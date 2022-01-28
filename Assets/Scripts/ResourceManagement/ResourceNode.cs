using UnityEngine;

namespace Creator.ResourceManagement
{
    public class ResourceNode : MonoBehaviour
    {
        [SerializeField] private Resource data;
        public int Value => data.ResourceValue;
    }
}
