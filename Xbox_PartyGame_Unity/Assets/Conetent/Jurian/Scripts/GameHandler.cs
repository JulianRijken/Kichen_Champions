using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHandler : MonoBehaviour
{
    public void SetWinner(int winner)
    {
        Debug.Log("Winner: Player " + winner);
    }
}
