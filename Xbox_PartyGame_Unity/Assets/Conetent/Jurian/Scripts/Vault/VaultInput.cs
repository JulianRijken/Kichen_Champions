﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Julian.InputSystem;
using UnityEngine.InputSystem;
using UnityEditor;


public class VaultInput : MonoBehaviour
{
    [Header("Required instances")]
    [SerializeField, Tooltip("Player Integer")] private int m_player;
    [SerializeField] private GameObject stand;
    [SerializeField] private Sprite Xbutton, Ybutton, AButton, Bbutton;
    [SerializeField] private SpriteRenderer ButtonToPress;

    [SerializeField, Header("Debug")] private ButtonSelection Button;

    private int m_correctPress;
    private bool GameRunning;
    private double delta;
    private Dictionary<ButtonSelection, Sprite> buttonText;
    private bool done;

    private Sprite sprite;

    private void Start()
    {
        if (PlayerInputCenter.PlayerExists(m_player))
        {
            PlayerInputCenter.PlayerInputEvents[m_player].OnButtonNorth += buttonNorthPressed;
            PlayerInputCenter.PlayerInputEvents[m_player].OnButtonEast += buttonEastPressed;
            PlayerInputCenter.PlayerInputEvents[m_player].OnButtonSouth += buttonSouthPressed;
            PlayerInputCenter.PlayerInputEvents[m_player].OnButtonWest += buttonWestPressed;
        }
        buttonText = new Dictionary<ButtonSelection, Sprite>();
        buttonText.Add(ButtonSelection.North, Ybutton);
        buttonText.Add(ButtonSelection.East, Bbutton);
        buttonText.Add(ButtonSelection.South, AButton);
        buttonText.Add(ButtonSelection.West, Xbutton);

        done = false;
        SelectButton();
    }

    IEnumerator StandFall()
    {
        int x = Random.Range(0, 2);

        for (int i = 0; i < 10; i++)
        {
            stand.transform.rotation = Quaternion.Lerp(stand.transform.rotation, Quaternion.Euler(0, 0, x == 0 ? -120 : 120), .1f);
            yield return new WaitForSeconds(.005f);
        }
    }

    private void SelectButton()
    {
        delta = 0;
        Button = (ButtonSelection)Random.Range((int)ButtonSelection.North, (int)ButtonSelection.West + 1);
        if (buttonText.TryGetValue(Button, out sprite))
        {
            if (ButtonToPress != null && ButtonToPress.sprite != null)
                ButtonToPress.sprite = sprite;
        }
    }

    private void buttonNorthPressed(InputAction.CallbackContext context)
    {
        if (context.performed && Button == ButtonSelection.North && !done)
        {
            m_correctPress += 1;
            // -- visuals
            SelectButton();
        }
        else if (context.performed && Button != ButtonSelection.North && !done)
        {
            m_correctPress -= 1;
            SelectButton();
        }
    }
    private void buttonEastPressed(InputAction.CallbackContext context)
    {
        if (context.performed && Button == ButtonSelection.East && !done)
        {
            m_correctPress += 1;
            // -- visuals
            SelectButton();
        }
        else if (context.performed && Button != ButtonSelection.East && !done)
        {
            m_correctPress -= 1;
            SelectButton();
        }
    }
    private void buttonSouthPressed(InputAction.CallbackContext context)
    {
        if (context.performed && Button == ButtonSelection.South && !done)
        {
            m_correctPress += 1;
            SelectButton();
        }
        else if(context.performed && Button != ButtonSelection.South && !done)
        {
            m_correctPress -= 1;
            SelectButton();
        }
    }
    private void buttonWestPressed(InputAction.CallbackContext context)
    {
        if (context.performed && Button == ButtonSelection.West && !done)
        {
            m_correctPress += 1;
            SelectButton();
        }
        else if (context.performed && Button != ButtonSelection.West && !done)
        {
            m_correctPress -= 1;
            SelectButton();
        }
    }

    private void Update()
    {
        delta += Time.deltaTime;
        if (m_correctPress > 7 && !done)
        {
            done = true;
            StartCoroutine(StandFall());
            MiniGameManager.SetPlayerDone(m_player);
        }

        if (delta >= .75 && !done)
        {
            SelectButton();
        }
        m_correctPress = Mathf.Clamp(m_correctPress, 0, 10);
    }

    private void OnDestroy()
    {
        if (PlayerInputCenter.PlayerExists(m_player))
        {
            PlayerInputCenter.PlayerInputEvents[m_player].OnButtonNorth -= buttonNorthPressed;
            PlayerInputCenter.PlayerInputEvents[m_player].OnButtonEast -= buttonEastPressed;
            PlayerInputCenter.PlayerInputEvents[m_player].OnButtonSouth -= buttonSouthPressed;
            PlayerInputCenter.PlayerInputEvents[m_player].OnButtonWest -= buttonWestPressed;
        }

    }
}
