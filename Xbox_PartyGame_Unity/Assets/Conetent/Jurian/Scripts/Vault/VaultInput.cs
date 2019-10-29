using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Julian.InputSystem;
using UnityEngine.InputSystem;
using UnityEditor;


public class VaultInput : MonoBehaviour
{
    [Header("Required instances")]
    [SerializeField, Tooltip("Player Integer")] private int m_player;
    [SerializeField] private Sprite Xbutton, Ybutton, AButton, Bbutton;

    [SerializeField, Header("Debug")] private ButtonSelection Button;
    private int m_correctPress;
    private bool GameRunning;
    private double delta;
    private Dictionary<ButtonSelection, Sprite> buttonText;
    private SpriteRenderer spriteRenderer;

    private Sprite sprite;

    private void Start()
    {
        PlayerInputCenter.PlayerInputEvents[m_player].OnButtonNorth += buttonNorthPressed;
        PlayerInputCenter.PlayerInputEvents[m_player].OnButtonEast += buttonEastPressed;
        PlayerInputCenter.PlayerInputEvents[m_player].OnButtonSouth += buttonSouthPressed;
        PlayerInputCenter.PlayerInputEvents[m_player].OnButtonWest += buttonWestPressed;
        buttonText = new Dictionary<ButtonSelection, Sprite>();
        buttonText.Add(ButtonSelection.North, Ybutton);
        buttonText.Add(ButtonSelection.East, Bbutton);
        buttonText.Add(ButtonSelection.South, AButton);
        buttonText.Add(ButtonSelection.West, Xbutton);
       
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        SelectButton();
    }

    private void SelectButton()
    {
        delta = 0;
        Button = (ButtonSelection)Random.Range((int)ButtonSelection.North, (int)ButtonSelection.West + 1);
        print(Button);
        if (buttonText.TryGetValue(Button, out sprite))
        {
            spriteRenderer.sprite = sprite;
        }
    }

    private void buttonNorthPressed(InputAction.CallbackContext context)
    {
        if (context.performed && Button == ButtonSelection.North)
        {
            m_correctPress += 1;
            // -- visuals
            SelectButton();
        }
        else if (context.performed && Button != ButtonSelection.North)
        {
            SelectButton();
        }
    }
    private void buttonEastPressed(InputAction.CallbackContext context)
    {
        if (context.performed && Button == ButtonSelection.East)
        {
            m_correctPress += 1;
            // -- visuals
            SelectButton();
        }
        else if (context.performed && Button != ButtonSelection.East)
        {
            SelectButton();
        }
    }
    private void buttonSouthPressed(InputAction.CallbackContext context)
    {
        if (context.performed && Button == ButtonSelection.South)
        {
            m_correctPress += 1;
            // -- visuals
            SelectButton();
        }
        else if(context.performed && Button != ButtonSelection.South)
        {
            SelectButton();
        }
    }
    private void buttonWestPressed(InputAction.CallbackContext context)
    {
        if (context.performed && Button == ButtonSelection.West)
        {
            m_correctPress += 1;
            // -- visuals
            SelectButton();
        }
        else if (context.performed && Button != ButtonSelection.West)
        {
            SelectButton();
        }
    }

    private void Update()
    {
        delta += Time.deltaTime;
        if (m_correctPress > 7)
        {
            MiniGameManager.SetPlayerDone(m_player);
        }

        if (delta >= .75)
        {
            SelectButton();
        }
    }
}
