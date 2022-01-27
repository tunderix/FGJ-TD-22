using System;
using System.Collections;
using System.Collections.Generic;
using Creator.Utilities;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Creator.UI
{
    /// <summary>
    /// Main Menu
    /// Attached only to main menu game-object and processes common main menu functionalities
    /// </summary>
    /// 
    public class MainMenu : MonoBehaviour
    {
        /// <summary>
        /// PlayGame
        /// Takes player to game level
        /// </summary>
        public void PlayGame()
        {
            SceneManager.LoadScene("GameLevel", LoadSceneMode.Single);
        }

        /// <summary>
        /// QuitGame
        /// What happens when quit game is pressed
        /// </summary>
        public void QuitGame()
        {
            // Logic for shutting game
            throw new NotSupportedException();
        }
    }
}
