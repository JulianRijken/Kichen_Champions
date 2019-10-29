using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{

    AsyncOperation operation;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            SceneLoader.LoadScene(SceneEnumName.SceneOne);
        }


        if (Input.GetKeyDown(KeyCode.E))
        {
            operation = SceneLoader.LoadSceneAsync(SceneEnumName.SceneTwo);
        }

        if (operation != null)
            Debug.Log(operation.progress);
    }
}
