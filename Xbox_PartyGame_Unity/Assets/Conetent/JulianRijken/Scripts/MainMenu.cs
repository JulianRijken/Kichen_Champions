using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{

    /// <summary>
    /// Starts the game
    /// </summary>
    public void StartGame()
    {
        SceneLoader.LoadSceneAsync(SceneEnumName.ControllerSetup);
    }

    /// <summary>
    /// Closes the application
    /// </summary>
    public void ExitApplication()
    {

        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #endif

        Application.Quit();
    }
}
