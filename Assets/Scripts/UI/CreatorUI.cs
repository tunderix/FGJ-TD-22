using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace Creator.UI
{
    /// <summary>
    /// Base UI
    /// </summary>
    public class CreatorUI : MonoBehaviour
    {
        [SerializeField] private bool inGameMenuActive;
        [SerializeField] private InGameMenu menu;

        private void Awake()
        {
            inGameMenuActive = false; 
            UpdateMenuVisibility();
        }

        /// <summary>
        /// Toggle menu visible/non-visible
        /// </summary>
        public void ToggleInGameMenu()
        {
            inGameMenuActive = !inGameMenuActive;
            UpdateMenuVisibility();
        }

        /// <summary>
        /// Update Menu Visibility
        /// </summary>
        public void UpdateMenuVisibility()
        {
            menu.gameObject.SetActive(inGameMenuActive);
        }
    }
}
