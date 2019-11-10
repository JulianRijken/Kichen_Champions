using Julian.InputSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TapeTheHolePlayer : MonoBehaviour
{
    [SerializeField] private int m_player;
    [SerializeField] private Transform m_tape;
    [SerializeField] private float m_moveSpeed;
    [SerializeField] private float m_noiseSpeed;
    [SerializeField] private int m_holeCount;
    [SerializeField] private float m_fixDistance;
    [SerializeField] private GameObject m_holesGroup;

    private TapeHole[] m_holes = new TapeHole[0];
    private Vector2 m_MovementInput;
    private Vector3 m_tapeStartPos;
    private int m_holesFixed;
    private float m_timer;

    void Start()
    {
        m_timer = Random.Range(0f, 100f);

        m_holesFixed = 0;

        if (PlayerInputCenter.PlayerExists(m_player))
        {
            PlayerInputCenter.PlayerInputEvents[m_player].OnMove += HandeMovement;
        }

        m_holes = m_holesGroup.GetComponentsInChildren<TapeHole>();
        //Debug.Log(m_holes.Length);

        for (int i = 0; i < m_holes.Length; i++)
        {
            m_holes[i].gameObject.SetActive(false);
        }

        m_tapeStartPos = m_tape.position;

        SetHoles();

    }

    private void OnDestroy()
    {
        if (PlayerInputCenter.PlayerExists(m_player))
        {
            PlayerInputCenter.PlayerInputEvents[m_player].OnMove -= HandeMovement;
        }
    }



    private void HandeMovement(InputAction.CallbackContext conext)
    {
        m_MovementInput = conext.ReadValue<Vector2>();
    }

    private void Update()
    {
        m_timer += Time.deltaTime;
        Vector2 perlinNoise = new Vector2(Mathf.PerlinNoise(m_timer, m_timer) - 0.5f, Mathf.PerlinNoise(m_timer, m_timer) - 0.5f);

        m_tape.transform.position += (Vector3)perlinNoise * Time.deltaTime * m_noiseSpeed;
        m_tape.transform.position += (Vector3)m_MovementInput * Time.deltaTime * m_moveSpeed;
    }

    private void SetHoles()
    {
        for (int i = 0; i < m_holeCount; i++)
        {
            List<TapeHole> closedHoles = new List<TapeHole>();

            for (int x = 0; x < m_holes.Length; x++)
            {
                if (!m_holes[x].gameObject.activeSelf)
                    closedHoles.Add(m_holes[x]);
            }

            if (closedHoles.Count > 0)
            {
                TapeHole hole = closedHoles[Random.Range(0, closedHoles.Count)];
                hole.gameObject.SetActive(true);
            }
        }

 
    }


    public void StickTape()
    {
        for (int i = 0; i < m_holes.Length; i++)
        {
            float distance = Vector2.Distance(m_tape.position, m_holes[i].transform.position);
            if (distance < m_fixDistance && !m_holes[i].isFixed)
            {
                m_holes[i].Fix();
                m_holesFixed++;
                if (m_holesFixed >= m_holeCount)
                {
                    MiniGameManager.SetPlayerDone(m_player);
                    m_tape.gameObject.SetActive(false);
                }
            }

        }

        m_tape.transform.position = m_tapeStartPos;

    }
}
