using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(fileName = "New SceneContainer", menuName = "New SceneContainer")]
public class SceneContainer : ScriptableObject
{
    [SerializeField] private SceneName[] scenes;
    //public int GetSceneIndex(SceneName sceneName)
    //{
        //SceneManager.getSc
       // return Array.Find(scenes,SceneName.Game);
    //}
}

public class SceneFinder
{
    //public 
}

public enum SceneName
{
   MainMenu,
   GameSetup,
   Game
}
