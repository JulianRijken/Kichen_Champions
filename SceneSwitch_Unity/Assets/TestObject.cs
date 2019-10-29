using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestObject : MonoBehaviour
{

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            SceneLoader.LoadSceneAsync(SceneEnumName.SceneOne);
        }


        if (Input.GetKeyDown(KeyCode.E))
        {
            SceneLoader.LoadSceneAsync(SceneEnumName.SceneTwo);
        }
    }
}
