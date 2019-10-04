using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputEvents : MonoBehaviour
{
    public void FireMove(InputAction.CallbackContext context)
    {
        OnMove?.Invoke(context);
    }
    public delegate void MoveAction(InputAction.CallbackContext context);
    public event MoveAction OnMove;

    public void OnDeviceLost()
    {
        GameManager.Instance.PlayerInputCenter.OnDeviceLost();
    }

    public void OnDeviceRegained()
    {
        GameManager.Instance.PlayerInputCenter.OnDeviceRegained();
    }
}
