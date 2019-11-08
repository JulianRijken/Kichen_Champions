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
    private int loopAmount;
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
        StartCoroutine(Move());
    }

    private void OnLeftTrigger(InputAction.CallbackContext conext)
    {

    }

    private void OnRightTrigger(InputAction.CallbackContext conext)
    {

    }

    private void Start()
    {
        loopAmount = 100;
        StartCoroutine(Move());
        saltAnchor = saltBottle.transform.Find("Emiter pos");

        if (PlayerInputCenter.PlayerExists(m_player))
        {
            PlayerInputCenter.PlayerInputEvents[m_player].OnLeftTrigger += OnLeftTrigger;
            PlayerInputCenter.PlayerInputEvents[m_player].OnRightTrigger += OnRightTrigger;
        }
    }

    private void Update()
    {
        Salt.gameObject.transform.position = saltAnchor.transform.position;
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
