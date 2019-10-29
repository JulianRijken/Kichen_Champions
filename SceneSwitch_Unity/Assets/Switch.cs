using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{

    private AsyncOperation operation;


    private void Awake()
    {
        SceneLoader.OnLoadSceneAsync += OnLoadScene;


    }

    private void OnDestroy()
    {
        SceneLoader.OnLoadSceneAsync -= OnLoadScene;
    }

    private void OnLoadScene(AsyncOperation operation)
    {
        Debug.Log("Test");
    }
}
