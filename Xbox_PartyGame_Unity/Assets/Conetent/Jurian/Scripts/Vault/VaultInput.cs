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
    [SerializeField] private GameObject stand;
    [SerializeField] private Sprite Xbutton, Ybutton, AButton, Bbutton;

    [SerializeField, Header("Debug")] private ButtonSelection Button;

    private int m_correctPress;
    private bool GameRunning;
    private double delta;
    private Dictionary<ButtonSelection, Sprite> buttonText;
    private SpriteRenderer spriteRenderer;
    private bool done;

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

        done = false;

        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        SelectButton();
    }

    IEnumerator StandFall()
    {

        for (int i = 0; i < 10; i++)
        {
            stand.transform.rotation = Quaternion.Lerp(stand.transform.rotation, Quaternion.Euler(0, 0, 85), .1f);
            yield return new WaitForSeconds(.005f);
        }
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
        if (context.performed && Button == ButtonSelection.North && !done)
        {
            m_correctPress += 1;
            // -- visuals
            SelectButton();
        }
        else if (context.performed && Button != ButtonSelection.North && !done)
        {
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
            SelectButton();
        }
    }
    private void buttonSouthPressed(InputAction.CallbackContext context)
    {
        if (context.performed && Button == ButtonSelection.South && !done)
        {
            m_correctPress += 1;
            // -- visuals
            SelectButton();
        }
        else if(context.performed && Button != ButtonSelection.South && !done)
        {
            SelectButton();
        }
    }
    private void buttonWestPressed(InputAction.CallbackContext context)
    {
        if (context.performed && Button == ButtonSelection.West && !done)
        {
            m_correctPress += 1;
            // -- visuals
            SelectButton();
        }
        else if (context.performed && Button != ButtonSelection.West && !done)
        {
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
    }
}
