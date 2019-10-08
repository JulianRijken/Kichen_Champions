using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Julian.InputSystem;
using UnityEngine.InputSystem;

public class PlayerCereal : MonoBehaviour
{
    [SerializeField] private Transform m_CerealBox;
    [SerializeField] private Transform m_Bole;
    [SerializeField] private int m_player;
    [SerializeField] private Vector2 m_MovementInput;

    void Start()
    {
        Debug.Log(PlayerInputCenter.PlayerInputEvents.Count);
        Debug.Log(m_player);
        PlayerInputCenter.PlayerInputEvents[m_player].OnMove += HandeMovement;
        
    }

    private void OnDestroy()
    {
        PlayerInputCenter.PlayerInputEvents[m_player].OnMove -= HandeMovement;
    }

    private void HandeMovement(InputAction.CallbackContext conext)
    {
        m_MovementInput = conext.ReadValue<Vector2>();
    }

   
    void Update()
    {
        Vector3 input = new Vector3(m_MovementInput.x,m_MovementInput.y,0);
        m_Bole.transform.position += input;
    }
}
