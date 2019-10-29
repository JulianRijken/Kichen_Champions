using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreCenter : MonoBehaviour
{

    private Dictionary<int, PlayerData> m_playerData;

    public void CreateNewPlayerData(int playerCount)
    {
        Debug.Log("New Player Data Created");

        m_playerData = new Dictionary<int, PlayerData>();

        for (int i = 0; i < playerCount; i++)
        {
            m_playerData.Add(i, new PlayerData());
        }
    }

    public PlayerData GetPlayerData(int player)
    {
        if (m_playerData.ContainsKey(player))
        {
            return m_playerData[player];
        }
        else
        {
            return null;
        }
    }

    public void AddScore(int player,int score)
    {
        if (m_playerData.ContainsKey(player))
            m_playerData[player].m_score += score;
    }
}


public class PlayerData
{
    public int m_score;
}
