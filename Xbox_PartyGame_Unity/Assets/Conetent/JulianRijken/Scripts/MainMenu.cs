﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public void StartGame()
    {
        SceneLoader.LoadSceneAsync(SceneEnumName.ControllerSetup);
    }
}
