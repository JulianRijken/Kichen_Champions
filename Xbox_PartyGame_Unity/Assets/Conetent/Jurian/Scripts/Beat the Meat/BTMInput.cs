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

    private bool cancel;
    private bool done;

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerInputCenter.PlayerExists(m_player))
            PlayerInputCenter.PlayerInputEvents[m_player].OnButtonSouth += buttonSouthPressed;

    }
    IEnumerator HammerIdle()
    {
        for (int i = 0; i < 10; i++)
        {
            m_hammer.transform.localRotation = Quaternion.Lerp(m_hammer.transform.rotation, Quaternion.Euler(0, 0, -105), 1f);
            m_hammer.transform.localPosition = Vector3.Lerp(m_hammer.transform.localPosition, new Vector3(-42.5f, -28,0), 1f);
            yield return new WaitForSeconds(.005f);
        }
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
            m_hammer.transform.rotation = Quaternion.Lerp(m_hammer.transform.rotation, Quaternion.Euler(0, 0, -40), m_tick);
            yield return new WaitForSeconds(.005f);
        }
    }
    IEnumerator Meat_movement()
    {
        for (int i = 0; i < 10; i++)
        {
            m_meat.transform.localScale = Vector3.Lerp(m_hammer.transform.localScale, new Vector3(1.3f,1, 1), m_tick);
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
        if (m_beats >= 50 && !done)
        {
            done = true;
            StartCoroutine(HammerIdle());
            MiniGameManager.SetPlayerDone(m_player);
        }
    }
    
}
