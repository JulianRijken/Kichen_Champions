using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotificationCenter
{
    public void FireGameStart(int playerCount)
    {
        OnGameStart?.Invoke(playerCount);
    }
    public delegate void GameStartAction(int playerCount);
    public event GameStartAction OnGameStart;

}
