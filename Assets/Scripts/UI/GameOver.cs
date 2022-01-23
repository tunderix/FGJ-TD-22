using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Creator.UI
{
    /// <summary>
    /// GameOver
    /// </summary>
    /// 
    public class GameOver : MonoBehaviour
    {
        /// <summary>
        /// PlayGame
        /// Takes player to game level
        /// </summary>
        public void PlayAgain()
        {
            SceneManager.LoadScene("GameLevel", LoadSceneMode.Single);
        }
        
        /// <summary>
        /// ToMenu
        /// Takes player to start menu
        /// </summary>
        public void ToMenu()
        {
            SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
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
