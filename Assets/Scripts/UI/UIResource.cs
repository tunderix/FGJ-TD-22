using System.Collections;
using System.Collections.Generic;
using Creator.ResourceManagement;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Creator.UI
{
    public class UIResource : MonoBehaviour
    {
        [SerializeField] private Image image;
        [SerializeField] private TextMeshProUGUI label;
        [SerializeField] private ResourceType resourceType;
    }
}
