using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Creator.UI
{
    /// <summary>
    /// InGameMenu
    /// Attached only to in-game menu game-object and processes common in-game UI functionalities
    /// </summary>
    public class InGameMenu : MonoBehaviour
    {
        /// <summary>
        /// QuitLevel
        /// What happens when quit game is pressed
        /// </summary>
        public void QuitLevel()
        {
            SceneManager.LoadScene("GameOver", LoadSceneMode.Single);
        }
            
    }
}
