using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    private static readonly object m_padLock = new object();
    private static GameManager instance;
    private Dictionary<int, PlayerData> m_playerData;
    
    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                lock (m_padLock)
                {
                
                        instance = new GameManager();
                  
                }
            }

            return instance;
        }
    }
    public Dictionary<int,PlayerData> PlayerData
    {
        get
        {
            if (m_playerData == null)
            {
                m_playerData = new Dictionary<int, PlayerData>();                
            }

            return m_playerData;
        }
    }


    public void AddPlayer(int user)
    {
        PlayerData.Add(user, new PlayerData());
    }

    public void RemovePlayer(int user)
    {
        PlayerData.Remove(user);
    }

    public PlayerData GetPlayerData(int user)
    {
        return PlayerData[user];
    }

}

public class PlayerData
{
    public int m_score;
    public Color m_playerColor;
}

