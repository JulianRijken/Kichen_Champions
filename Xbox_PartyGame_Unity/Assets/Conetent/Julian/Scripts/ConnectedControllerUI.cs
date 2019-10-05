using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class ConnectedControllerUI : MonoBehaviour
{
    [SerializeField] private int m_user;


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
            GetComponent<Image>().color = Color.blue;
        }
        else
        {
            GetComponent<Image>().color = Color.gray;
        }
    }

}
