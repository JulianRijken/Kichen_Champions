using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Julian.InputSystem;
using UnityEngine.InputSystem;

public class SliceItInput : MonoBehaviour
{
    [SerializeField, Header("Required")] private int m_player;
    [SerializeField] private Rigidbody2D cucumber;

    private float scale;
    private Vector2 m_MovementInput;
    private Vector3 input;
    private Vector3 startpos;
    private bool done;
    private Vector3 topos;

    private int slices;


    // Start is called before the first frame update
    void Start()
    {
        scale = 2.5f;
        if (PlayerInputCenter.PlayerExists(m_player))
        {
            PlayerInputCenter.PlayerInputEvents[m_player].OnMove += StickMovement;
        }
        startpos = cucumber.position;
        topos = startpos;
        done = false;
    }


    private void StickMovement(InputAction.CallbackContext conext)
    {
        m_MovementInput = conext.ReadValue<Vector2>();
        if (!done)
            MoveCucumber();
    }

    private void MoveCucumber()
    {
        input = new Vector3(m_MovementInput.x, 0, 0);
        topos = Vector3.Lerp(startpos, startpos + input, Time.deltaTime);
            
        cucumber.MovePosition(Vector3.Lerp(cucumber.position, topos, Time.deltaTime * 3));
    }
    private void OnDestroy()
    {
        if (PlayerInputCenter.PlayerExists(m_player))
        {
            PlayerInputCenter.PlayerInputEvents[m_player].OnMove -= StickMovement;
        }
    }
}
