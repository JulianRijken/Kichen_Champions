using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Julian.InputSystem;
using UnityEngine.InputSystem;
public class BTMInput : MonoBehaviour
{
    [SerializeField] private int m_player;
    [SerializeField] private int m_beats;

    [SerializeField] private GameObject m_hammer;
    [SerializeField] private GameObject m_meat;

    [SerializeField] private float m_tick;
    [SerializeField] private Transform position;

    private bool cancel;
    private bool done;

    private Animator Controller;

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerInputCenter.PlayerExists(m_player))
            PlayerInputCenter.PlayerInputEvents[m_player].OnButtonSouth += buttonSouthPressed;

    }
    IEnumerator HammerIdle()
    {
        for (int i = 0; i < 100; i++)
        {
            m_hammer.transform.localRotation = Quaternion.Slerp(m_hammer.transform.localRotation, Quaternion.Euler(0, 0, -110), Time.deltaTime * 10f);
            m_hammer.transform.localPosition = Vector3.Lerp(m_hammer.transform.localPosition, position.localPosition, Time.deltaTime * 10f);
            yield return new WaitForSeconds(.01f);
        }
    }
    IEnumerator Hammer_movement()
    {
        for (int i = 0; i < 10; i++)
        {
            cancel = true;
            m_hammer.transform.localRotation = Quaternion.Slerp(m_hammer.transform.localRotation, Quaternion.Euler(0, 0, 0), Time.deltaTime * m_tick);
            yield return new WaitForSeconds(.005f);
        }
        StartCoroutine(Meat_movement());
        cancel = false;
        for (int i = 0; i < 10; i++)
        {
            if (cancel) {cancel = false; break;}
            m_hammer.transform.localRotation = Quaternion.Slerp(m_hammer.transform.localRotation, Quaternion.Euler(0, 0, -40), Time.deltaTime *  m_tick);
            yield return new WaitForSeconds(.005f);
        }
    }
    IEnumerator Meat_movement()
    {
        for (int i = 0; i < 10; i++)
        {
            m_meat.transform.localScale = Vector3.Lerp(m_hammer.transform.localScale, new Vector3(1.3f,1, 1), Time.deltaTime * m_tick);
            yield return new WaitForSeconds(.005f);
        }
        for (int i = 0; i < 10; i++)
        {
            m_meat.transform.localScale = Vector3.Lerp(m_hammer.transform.localScale, new Vector3(1, 1, 1), m_tick); 
            yield return new WaitForSeconds(.005f);
        }
    }

    private void buttonSouthPressed(InputAction.CallbackContext context)
    {
        if (context.performed && !done)
        {
            m_beats += 1;
            StartCoroutine(Hammer_movement());
        }
    }

    private void OnDestroy()
    {
        if (PlayerInputCenter.PlayerExists(m_player))
            PlayerInputCenter.PlayerInputEvents[m_player].OnButtonSouth -= buttonSouthPressed;
        
    }

    private void Update()
    {
        if (m_beats == 10 && !done)
        {
            done = true;
            StartCoroutine(HammerIdle());
            MiniGameManager.SetPlayerDone(m_player);
        }
    }
    
}
