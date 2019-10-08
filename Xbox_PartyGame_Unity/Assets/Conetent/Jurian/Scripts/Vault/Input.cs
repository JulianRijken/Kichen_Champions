using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Julian.InputSystem;
using UnityEngine.InputSystem;
public class Input : MonoBehaviour
{
    [SerializeField] private int m_player;
    [SerializeField] private int m_beats;
    [SerializeField] private GameHandler gameHandler;
    // Start is called before the first frame update
    void Start()
    {
        PlayerInputCenter.PlayerInputEvents[m_player].OnButtonSouth += buttonSouthPressed;
    }

    private void buttonSouthPressed(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            m_beats += 1;
            // visuals  
        }
    }

    private void OnDestroy()
    {
        PlayerInputCenter.PlayerInputEvents[m_player].OnButtonSouth -= buttonSouthPressed;
    }

    private void Update()
    {
        if (m_beats >= 20)
        {
            gameHandler.SetWinner(m_player);
        }
    }
}
