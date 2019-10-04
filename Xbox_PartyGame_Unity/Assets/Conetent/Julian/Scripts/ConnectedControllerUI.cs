using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class ConnectedControllerUI : MonoBehaviour
{
    [SerializeField] private int playerId;

    private PlayerInputEvents m_playerInputEvent;
    private bool m_playerConnected;


    void Start()
    {

        Dictionary<int,PlayerInputEvents> playerInputEvents = GameManager.Instance.PlayerInputCenter.PlayerInputEvents;
        m_playerConnected = playerInputEvents.ContainsKey(playerId) ? true : false;

        if (m_playerConnected)
        {
            m_playerInputEvent = playerInputEvents[playerId];
            m_playerInputEvent.OnMove += Move;
        }
        else
        {
            GetComponent<Image>().color = Color.gray;
        }
    }

    private void OnDestroy()
    {
        if(m_playerConnected)
            m_playerInputEvent.OnMove -= Move;
    }


    public void Move(InputAction.CallbackContext context)
    {
        if(context.ReadValue<Vector2>().magnitude > 0)
            GetComponent<Image>().color = Color.green;
        else
            GetComponent<Image>().color = Color.black;
    }

}
