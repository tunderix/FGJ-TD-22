using System.Collections.Generic;
using Creator.Buildings;
using Creator.ResourceManagement;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

namespace Creator.UI
{
    public class ActionButton : MonoBehaviour
    {
        [SerializeField] BuildingData building;
        [SerializeField] private TextMeshProUGUI buttonLabel; 
        [SerializeField] private Button button;
        
        private void Start()
        {
            buttonLabel.SetText(building.name);
            SetButtonColor(Color.red);
        }

        public void UpdateContents(bool canBuild)
        {
            SetButtonColor(canBuild ? Color.white : Color.red);
        }

        private void SetButtonColor(Color color)
        {
            var colorValues = button.colors; 
            colorValues.normalColor = color;
            button.colors = colorValues;
        }
    }
}
