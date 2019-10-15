using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GameHandler : MonoBehaviour
{
    private bool GameRunning;
    public bool Gamerunning { get { return GameRunning; } }
    public enum ButtonSelection
    {
        North = 0,
        East,
        South,
        West
    }

    public void SetWinner(int winner)
    {
        Debug.Log("Winner: Player " + winner);
        GameRunning = false;
    }
    
    public ButtonSelection RandomButtonSelection()
    {
        int i = Random.Range((int)ButtonSelection.North, (int)ButtonSelection.West + 1);
        return (ButtonSelection)i;
    }
}
