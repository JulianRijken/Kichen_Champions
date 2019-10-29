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
    [SerializeField] private GameHandler GameHandler;
    [SerializeField] private Sprite Xbutton, Ybutton, AButton, Bbutton;

    [SerializeField, Header("Debug")] private GameHandler.ButtonSelection Button;
    private int m_correctPress;
    private bool GameRunning;
    private double delta;
    private Dictionary<GameHandler.ButtonSelection, Sprite> buttonText;
    private SpriteRenderer spriteRenderer;

    private Sprite sprite;

    private void Start()
    {
        PlayerInputCenter.PlayerInputEvents[m_player].OnButtonNorth += buttonNorthPressed;
        PlayerInputCenter.PlayerInputEvents[m_player].OnButtonEast += buttonEastPressed;
        PlayerInputCenter.PlayerInputEvents[m_player].OnButtonSouth += buttonSouthPressed;
        PlayerInputCenter.PlayerInputEvents[m_player].OnButtonWest += buttonWestPressed;
        buttonText = new Dictionary<GameHandler.ButtonSelection, Sprite>();
        buttonText.Add(GameHandler.ButtonSelection.North, Ybutton);
        buttonText.Add(GameHandler.ButtonSelection.East, Bbutton);
        buttonText.Add(GameHandler.ButtonSelection.South, AButton);
        buttonText.Add(GameHandler.ButtonSelection.West, Xbutton);
       
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        ButtonSelection();
    }

    private void ButtonSelection()
    {
        delta = 0;
        Button = GameHandler.RandomButtonSelection();
        print(Button);
        if (buttonText.TryGetValue(Button, out sprite))
        {
            spriteRenderer.sprite = sprite;
        }
    }

    private void buttonNorthPressed(InputAction.CallbackContext context)
    {
        if (context.performed && Button == GameHandler.ButtonSelection.North)
        {
            m_correctPress += 1;
            // -- visuals
            ButtonSelection();
        }
        else if (context.performed && Button != GameHandler.ButtonSelection.North)
        {
            ButtonSelection();
        }
    }
    private void buttonEastPressed(InputAction.CallbackContext context)
    {
        if (context.performed && Button == GameHandler.ButtonSelection.East)
        {
            m_correctPress += 1;
            // -- visuals
            ButtonSelection();
        }
        else if (context.performed && Button != GameHandler.ButtonSelection.East)
        {
            ButtonSelection();
        }
    }
    private void buttonSouthPressed(InputAction.CallbackContext context)
    {
        if (context.performed && Button == GameHandler.ButtonSelection.South)
        {
            m_correctPress += 1;
            // -- visuals
            ButtonSelection();
        }
        else if(context.performed && Button != GameHandler.ButtonSelection.South)
        {
            ButtonSelection();
        }
    }
    private void buttonWestPressed(InputAction.CallbackContext context)
    {
        if (context.performed && Button == GameHandler.ButtonSelection.West)
        {
            m_correctPress += 1;
            // -- visuals
            ButtonSelection();
        }
        else if (context.performed && Button != GameHandler.ButtonSelection.West)
        {
            ButtonSelection();
        }
    }

    private void Update()
    {
        delta += Time.deltaTime;
        if (m_correctPress > 7)
        {
            GameHandler.SetWinner(m_player);
        }

        if (delta >= .75)
        {
            ButtonSelection();
        }
    }
}
