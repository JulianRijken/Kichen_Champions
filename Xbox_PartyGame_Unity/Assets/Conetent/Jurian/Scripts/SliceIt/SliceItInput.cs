using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Julian.InputSystem;
using UnityEngine.InputSystem;

public class SliceItInput : MonoBehaviour
{
    [SerializeField, Header("Required")] private int m_player;
    private float scale;
    private Vector2 m_MovementInput;
    private Vector3 input;
    // Start is called before the first frame update
    void Start()
    {
        scale = 3;
        if (PlayerInputCenter.PlayerExists(m_player))
        {
            PlayerInputCenter.PlayerInputEvents[m_player].OnMove += StickMovement;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void StickMovement(InputAction.CallbackContext conext)
    {
        m_MovementInput = conext.ReadValue<Vector2>();
    }

    private void MoveCucumber()
    {
        input = new Vector3(m_MovementInput.x, 0, 0);
        input.x = Mathf.Clamp(input.x, -scale, scale);
    }
}
