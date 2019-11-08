using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Julian.InputSystem;
using UnityEngine.InputSystem;

public class STMInput : MonoBehaviour
{
    [SerializeField] private int m_player;
    [SerializeField] private GameObject saltBottle;
    [SerializeField] private ParticleSystem Salt;

    private Transform saltAnchor;
    private int Points;
    private bool Left, Right;
    private bool Cancel;
    private bool done;

    IEnumerator Move()
    {
        for (int i = 0; i < 100; ++i)
        {
            yield return new WaitForEndOfFrame();
            saltBottle.transform.localPosition = Vector3.MoveTowards(saltBottle.transform.localPosition, new Vector3(-5f, 2f, 0), 0.02f);
        }
        for (int i = 0; i < 100; ++i)
        {
            yield return new WaitForEndOfFrame();
            saltBottle.transform.localPosition = Vector3.MoveTowards(saltBottle.transform.localPosition, new Vector3(1.47f, 1.32f, 0), 0.02f);
        }
        if (!done)
            StartCoroutine(Move());
    }

    IEnumerator EnableSalt()
    {
        Salt.Play();
        if (Cancel) { Cancel = false; yield break; }
        yield return new WaitForSeconds(.2f);
        if (Cancel) { Cancel = false; yield break; }
        Salt.Stop();

    }

    private void OnLeftTrigger(InputAction.CallbackContext context)
    {
        if (context.performed && !Left && !done)
        {
            Debug.Log("LeftTrigger");
            Left = true;
            Right = false;
            Points += 1;
            StartCoroutine(EnableSalt());
            Cancel = true;
        }
    }

    private void OnRightTrigger(InputAction.CallbackContext context)
    {
        if (context.performed && !Right && !done)
        {
            Debug.Log("RightTrigger");
            Right = true;
            Left = false;
            Points += 1;
            StartCoroutine(EnableSalt());
            Cancel = true;
        }
    }

    private void Start()
    {
        StartCoroutine(Move());
        
        saltAnchor = saltBottle.transform.Find("Emiter pos");
        Left = false;
        Right = true;
        Salt.Stop();

        if (PlayerInputCenter.PlayerExists(m_player))
        {
            PlayerInputCenter.PlayerInputEvents[m_player].OnLeftTrigger += OnLeftTrigger;
            PlayerInputCenter.PlayerInputEvents[m_player].OnRightTrigger += OnRightTrigger;
        }
    }

    private void Update()
    {
        Salt.gameObject.transform.position = saltAnchor.transform.position;

        if (Points == 60 && !done)
        {
            done = true;
            MiniGameManager.SetPlayerDone(m_player);
        }
    }

    private void OnDestroy()
    {
        if (PlayerInputCenter.PlayerExists(m_player))
        {
            PlayerInputCenter.PlayerInputEvents[m_player].OnLeftTrigger -= OnLeftTrigger;
            PlayerInputCenter.PlayerInputEvents[m_player].OnRightTrigger -= OnRightTrigger;
        }
    }
}
