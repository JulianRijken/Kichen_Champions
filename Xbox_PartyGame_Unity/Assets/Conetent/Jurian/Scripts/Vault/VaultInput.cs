using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Julian.InputSystem;
using UnityEngine.InputSystem;
public class VaultInput : MonoBehaviour
{
    [SerializeField, Tooltip("Player Integer")] private int m_player;
    [SerializeField] private GameHandler GameHandler;
    [SerializeField] private GameHandler.ButtonSelection Button;

    private int m_correctPress;
    private bool GameRunning;

    IEnumerator GetButton()
    {
        Button = GameHandler.RandomButtonSelection();
        // visuals
        yield return new WaitForSeconds(.5f);
        if (GameHandler.Gamerunning)
        {
            StartCoroutine(GetButton());
        }
    }

    private void Start()
    {
        PlayerInputCenter.PlayerInputEvents[m_player].OnButtonSouth += buttonSouthPressed;
        StartCoroutine(GetButton());
    }

    private void buttonSouthPressed(InputAction.CallbackContext context)
    {
        if (context.performed && Button == GameHandler.ButtonSelection.South)
        {
            
        }
    }

}
