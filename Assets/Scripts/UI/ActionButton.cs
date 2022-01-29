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
        [SerializeField] private Recipe recipe;
        
        private void Start()
        {
            buttonLabel.SetText(building.name);
            SetButtonColor(Color.red);
        }

        public void UpdateContents(int crystals,int woods)
        {
            UpdateBuildingTypeContent(BuildingType.Gatherer, crystals, woods);
            UpdateBuildingTypeContent(BuildingType.Warehouse, crystals, woods);
            UpdateBuildingTypeContent(BuildingType.Tower, crystals, woods);
        }

        private void UpdateBuildingTypeContent(BuildingType buildingType, int crystals, int woods)
        {
            if (building.BuildingType == buildingType)
            {
                var canBuild = recipe.CanBuild(crystals, woods);
                SetButtonColor(canBuild ? Color.white : Color.red);
                /*
                foreach (var resourceNeed in recipe.ResourcesNeeded)
                {
                    var hasEnoughCrystals = resourceNeed.ResourceType == ResourceType.Crystal &&
                                            resourceNeed.isEnough(crystals);
                    var hasEnoughWood = resourceNeed.ResourceType == ResourceType.Wood &&
                                        resourceNeed.isEnough(woods);
                }
                */
            }
        }

        private void SetButtonColor(Color color)
        {
            var colorValues = button.colors; 
            colorValues.normalColor = color;
            button.colors = colorValues;
        }
    }
}
