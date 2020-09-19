using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using Julian.InputSystem;

public class ConnectedControllerUI : MonoBehaviour
{

    [SerializeField] private int m_user;
    [SerializeField] private Color m_activeColor;
    [SerializeField] private Color m_inActiveColor;
    [SerializeField] private Image m_image;

    void Start()
    {
        PlayerInputCenter.Instance.OnDevicesReset += UpdateStatus;

        UpdateStatus();
    }

    private void OnDestroy()
    {
        PlayerInputCenter.Instance.OnDevicesReset -= UpdateStatus;
    }

    private void UpdateStatus()
    {
        bool userConnected = PlayerInputCenter.PlayerInputEvents.ContainsKey(m_user);

        if (userConnected)
        {
            m_image.color = m_activeColor;
        }
        else
        {
            m_image.color = m_inActiveColor;
        }
    }

}
