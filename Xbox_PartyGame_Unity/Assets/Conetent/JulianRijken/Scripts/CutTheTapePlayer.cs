using Julian.InputSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CutTheTapePlayer : MonoBehaviour
{

    [SerializeField] private int m_player;

    [SerializeField] private Animator m_siccorsAnimator;
    [SerializeField] private Transform m_cutPoint;
    [SerializeField] private Transform m_ruller;
    [SerializeField] private Transform m_tape;
    [SerializeField] private GameObject m_cutTape;
    [SerializeField] private Vector2 m_randomLength;
    [SerializeField] private float m_tapeSpeed;
    [SerializeField] private float m_tapePauseTime;
    [SerializeField] private float m_goodCutRange;
    [SerializeField] private int m_cutsToWin;

    private float m_hasToCutLength;
    private bool m_canMove;
    private bool m_isDone;
    private int m_goodCuts;

    private void Start()
    {

        if (PlayerInputCenter.PlayerExists(m_player))
        {
            PlayerInputCenter.PlayerInputEvents[m_player].OnButtonSouth += HandelButton;
        }

        m_canMove = true;
        m_isDone = false;
        m_goodCuts = 0;

        Vector3 newRulerPos = m_ruller.position;
        newRulerPos.y = m_cutPoint.position.y;
        m_ruller.transform.position = newRulerPos;

        ResetRuller();
    }


    private void OnDestroy()
    {
        if (PlayerInputCenter.PlayerExists(m_player))
        {
            PlayerInputCenter.PlayerInputEvents[m_player].OnButtonSouth -= HandelButton;
        }
    }

    private void Update()
    {
        if (m_isDone)
        {
            m_tape.transform.position -= Vector3.down * Time.deltaTime * m_tapeSpeed * 2f;
        }
        else
        {
            if (m_canMove)
                m_tape.transform.position += Vector3.down * Time.deltaTime * m_tapeSpeed;
        }
    }

    private IEnumerator PauseTape()
    {
        m_canMove = false;
        yield return new WaitForSeconds(m_tapePauseTime);
        m_canMove = true;
    }

    private void HandelButton(InputAction.CallbackContext conext)
    {
        if (conext.performed && !m_isDone)
        {
            m_siccorsAnimator.SetTrigger("Cut");
        }

    }

    private void ResetRuller()
    {
        m_hasToCutLength = Random.Range(m_randomLength.x, m_randomLength.y);
        Vector3 newScale = m_ruller.localScale;
        newScale.y = m_hasToCutLength;
        m_ruller.localScale = newScale;
    }

    public void Cut()
    {
        Vector3 tapeEdge = m_tape.transform.position;
        tapeEdge.y -= m_tape.localScale.y / 2f;

        float cutLength =  m_cutPoint.position.y - tapeEdge.y;
        cutLength = Mathf.Clamp(cutLength, 0, Mathf.Infinity);

        Debug.Log("Cut Length: " + cutLength);
        Debug.Log("hasToCut Length: " + m_hasToCutLength);
        bool goodCut;
        if (cutLength >= m_hasToCutLength - m_goodCutRange && cutLength <= m_hasToCutLength + m_goodCutRange)
        {
            goodCut = true;
            m_goodCuts++;

            if (m_goodCuts >= m_cutsToWin)
            {
                m_isDone = true;
                MiniGameManager.SetPlayerDone(m_player);
            }
        }
        else
        {
            goodCut = false;
        }

        m_tape.transform.position += Vector3.up * cutLength;


        Vector3 spawnPos = m_cutPoint.transform.position + Vector3.down * cutLength / 2;
        spawnPos.x = m_tape.position.x;

        GameObject cutTape = Instantiate(m_cutTape, spawnPos, Quaternion.identity);
        SpriteRenderer spriteRenderer = cutTape.GetComponent<SpriteRenderer>();
        if (spriteRenderer != null)
        {
            if (goodCut)
                spriteRenderer.color = Color.green;
            else
                spriteRenderer.color = Color.red;
        }

        Vector3 cutTapeScale = m_tape.transform.localScale;
        cutTapeScale.y = cutLength;
        cutTape.transform.localScale = cutTapeScale;



        ResetRuller();

        if(m_canMove == true)
            StartCoroutine(PauseTape());
    }
}
