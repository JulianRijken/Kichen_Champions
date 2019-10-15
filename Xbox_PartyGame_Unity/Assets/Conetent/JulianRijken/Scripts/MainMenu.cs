using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    //[SerializeField] private Scene levelSelectScene;

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }
}
