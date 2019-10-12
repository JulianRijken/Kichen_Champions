﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Julian.InputSystem;
using UnityEngine.InputSystem;
public class Input : MonoBehaviour
{
    [SerializeField] private int m_player;
    [SerializeField] private int m_beats;

    [SerializeField] private GameObject m_hammer;
    [SerializeField] private GameObject m_meat;

    [SerializeField] private GameHandler gameHandler;
    [SerializeField] private float m_tick;

    private bool cancel;
    // Start is called before the first frame update
    void Start()
    {
        PlayerInputCenter.PlayerInputEvents[m_player].OnButtonSouth += buttonSouthPressed;

    }

    IEnumerator Hammer_movement()
    {
        for (int i = 0; i < 10; i++)
        {
            cancel = true;
            m_hammer.transform.rotation = Quaternion.Lerp(m_hammer.transform.rotation, Quaternion.Euler(0, 0, 0), m_tick);
            yield return new WaitForSeconds(.005f);
        }
        StartCoroutine(Meat_movement());
        cancel = false;
        for (int i = 0; i < 10; i++)
        {
            if (cancel) {cancel = false; break;}
            m_hammer.transform.rotation = Quaternion.Lerp(m_hammer.transform.rotation, Quaternion.Euler(0, 0, -30), m_tick);
            yield return new WaitForSeconds(.005f);
        }
    }
    IEnumerator Meat_movement()
    {
        for (int i = 0; i < 10; i++)
        {
            m_meat.transform.localScale = Vector3.Lerp(m_hammer.transform.localScale, new Vector3(30,20, 1), m_tick);
            yield return new WaitForSeconds(.005f);
        }
        for (int i = 0; i < 10; i++)
        {
            m_meat.transform.localScale = Vector3.Lerp(m_hammer.transform.localScale, new Vector3(22, 22, 1), m_tick); 
            yield return new WaitForSeconds(.005f);
        }
    }

    private void buttonSouthPressed(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            m_beats += 1;
            StartCoroutine(Hammer_movement());
        }
    }

    private void OnDestroy()
    {
        PlayerInputCenter.PlayerInputEvents[m_player].OnButtonSouth -= buttonSouthPressed;
    }

    private void Update()
    {
        if (m_beats >= 60)
        {
            gameHandler.SetWinner(m_player);
        }
    }
}
