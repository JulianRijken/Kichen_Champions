using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EindScreen : MonoBehaviour
{
    
    public void Exit()
    {
        SceneLoader.LoadSceneAsync(SceneEnumName.MainMenu);
    }

}
