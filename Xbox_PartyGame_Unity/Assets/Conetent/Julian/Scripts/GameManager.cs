using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GameManager : MonoBehaviour
{


    private int m_connectedPlayersAtStart;
    private Dictionary<int, PlayerData> m_playerData;

    public static GameManager Instance { get; private set; }
    public Dictionary<int, PlayerData> PlayerData
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
    public int ConnectedPlayersAtStart
    {
        get => m_connectedPlayersAtStart;     
        set
        {
            if (value > 4)          
                m_connectedPlayersAtStart = 4;           
            else            
                m_connectedPlayersAtStart = value;       
        }

    }


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(Instance.gameObject);
        }
        else if (this != Instance)
        {
            Destroy(this.gameObject);
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

