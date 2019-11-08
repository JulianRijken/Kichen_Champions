using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Julian.InputSystem
{
    public class PlayerInputEvents : MonoBehaviour
    {

        public PlayerInput m_playerInput;

        public void FireMove(InputAction.CallbackContext context)
        {
            OnMove?.Invoke(context);
        }
        public delegate void MoveAction(InputAction.CallbackContext context);
        public event MoveAction OnMove;

        public void FireButtonNorth(InputAction.CallbackContext context)
        {
            OnButtonNorth?.Invoke(context);
        }
        public delegate void ButtonNorthAction(InputAction.CallbackContext context);
        public event ButtonNorthAction OnButtonNorth;

        public void FireButtonEast(InputAction.CallbackContext context)
        {
            OnButtonEast?.Invoke(context);
        }
        public delegate void ButtonEastAction(InputAction.CallbackContext context);
        public event ButtonEastAction OnButtonEast;

        public void FireButtonSouth(InputAction.CallbackContext context)
        {
            OnButtonSouth?.Invoke(context);
        }
        public delegate void ButtonSouthAction(InputAction.CallbackContext context);
        public event ButtonSouthAction OnButtonSouth;

        public void FireButtonWest(InputAction.CallbackContext context)
        {
            OnButtonWest?.Invoke(context);
        }
        public delegate void ButtonWestAction(InputAction.CallbackContext context);
        public event ButtonWestAction OnButtonWest;

        public void FireLeftTrigger(InputAction.CallbackContext context)
        {
            OnLeftTrigger?.Invoke(context);
        }

        public delegate void LeftTriggerAction(InputAction.CallbackContext context);
        public event LeftTriggerAction OnLeftTrigger;

        public void FireRightTrigger(InputAction.CallbackContext context)
        {
            OnRightTrigger?.Invoke(context);
        }

        public delegate void RightTriggerAction(InputAction.CallbackContext context);
        public event RightTriggerAction OnRightTrigger;

        public void OnDeviceLost()
        {
            PlayerInputCenter.Instance.FireOnDeviceLost();
        }

        public void OnDeviceRegained()
        {
            PlayerInputCenter.Instance.FireOnDeviceRegained();
        }
    }
}
