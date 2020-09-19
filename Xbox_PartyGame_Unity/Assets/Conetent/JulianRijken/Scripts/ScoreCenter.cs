using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreCenter
{

    private Dictionary<int, PlayerData> m_playerData;
    private int m_gameLength = 5;
    private PlayerData m_winningPlayer;

    public void SetWinningPlayer(PlayerData player)
    {
        m_winningPlayer = player;
    }

    public PlayerData GetWinningPlayer()
    {
        return m_winningPlayer;
    }

    public void CreateNewPlayerData(int playerCount)
    {
        Debug.Log("New Player Data Created");

        m_playerData = new Dictionary<int, PlayerData>();

        for (int i = 0; i < playerCount; i++)
        {

            m_playerData.Add(i, new PlayerData(0,i));
        }
    }

    public int GetGameLength()
    {
        return m_gameLength;
    }

    public void SetGameLength(int gameLengh)
    {
        Debug.Log("Game length Set: " + gameLengh);
        m_gameLength = gameLengh;
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
    public PlayerData(int score,int player)
    {
        m_score = score;
        m_player = player;
    }

    public int m_score;
    public int m_player;
}
