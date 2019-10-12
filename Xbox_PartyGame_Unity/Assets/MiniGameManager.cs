using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Julian.InputSystem;
using UnityEditor;

public class MiniGameManager : MonoBehaviour
{

    [SerializeField] private Transform[] m_players;
    [SerializeField] private float m_unitsBitween;
    [SerializeField] private int m_playerCount;

    void Awake()
    {
        m_playerCount = 2;//PlayerInputCenter.SelectedPlayerCount;

        AlighnPlayers();

    }

    [ContextMenu("Reset Pos")]
    private void AlighnPlayers()
    {
        for (int i = 0; i < m_players.Length; i++)
            m_players[i].gameObject.SetActive(false);

        float centerX = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width / 2, 0, 0)).x;

        for (int i = 0; i < m_playerCount; i++)
        {
            float a = m_unitsBitween;
            float b = m_playerCount;

            float posX = centerX - ((a * b - a) / 2f) + a * i;

            Vector2 newPos = new Vector2(posX, transform.position.y);
            m_players[i].position = newPos;
            m_players[i].gameObject.SetActive(true);
        }
    }

}
