using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputCenter : MonoBehaviour
{
    [SerializeField] private PlayerInputManager m_playerInputManager;
    [SerializeField] private GameObject m_playerInputPrefab;

    private Dictionary<int, PlayerInputEvents> m_playerInputEvents;

    public Dictionary<int, PlayerInputEvents> PlayerInputEvents
    {
        get
        {
            if (m_playerInputEvents == null)
            {
                m_playerInputEvents = new Dictionary<int, PlayerInputEvents>();
            }

            return m_playerInputEvents;
        }
    }


    private void Awake()
    {
        m_playerInputEvents =  new Dictionary<int, PlayerInputEvents>();

        m_playerInputManager.playerPrefab = m_playerInputPrefab;
        
        foreach (var device in InputDevice.all)
        {
            m_playerInputManager.JoinPlayer();
        }
    }


    public void OnPlayerJoined(PlayerInput joinedPlayer)
    {
        joinedPlayer.transform.SetParent(this.transform);
        m_playerInputEvents.Add(joinedPlayer.user.index, joinedPlayer.GetComponent<PlayerInputEvents>());
    }

    public void OnDeviceLost()
    {
        Debug.Log("DEVICE LOST RECCONECT DEVICE");
    }

    public void OnDeviceRegained()
    {
        Debug.Log("DEVICE RECCONECTED");
    }

}
