using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Julian.InputSystem;
using UnityEditor;

public class PlayerAlignment : MonoBehaviour
{

    [SerializeField] private GameObject[] m_players;
    [SerializeField] private int m_playerCount;
    [SerializeField] private bool m_align;
    [SerializeField] private bool m_Grid;
    [SerializeField] private CenterType m_centerType;
    [SerializeField] private float m_unitsBitweenX;
    [SerializeField] private float m_unitsBitweenY;

    private enum CenterType { camera, thisTransform}

    void Awake()
    {
        m_playerCount = PlayerInputCenter.SelectedPlayerCount;
        ResetPlayers();
    }

    [ContextMenu("Test Align")]
    private void ResetPlayers()
    {
        for (int i = 0; i < m_players.Length; i++)
            m_players[i].SetActive(false);

        for (int i = 0; i < m_playerCount; i++)
            m_players[i].SetActive(true);

        if (m_align)
        {
            float centerX;
            float centerY;

            if (m_centerType == CenterType.camera)
            {
                centerX = Camera.main.transform.position.x;
                centerY = Camera.main.transform.position.y;
            }
            else
            {
                RectTransform rectTransform = GetComponent<RectTransform>();
                if (rectTransform == null)
                {
                    centerX = transform.position.y;
                    centerY = transform.position.x;
                }
                else
                {
                    centerX = rectTransform.position.x;
                    centerY = rectTransform.position.y;
                }
            }

            bool m_gridLocal = m_Grid;

            if (m_playerCount == 2 && m_gridLocal) m_gridLocal = false;

            if (m_gridLocal)
            {
                for (int i = 0; i < m_playerCount; i++)
                {
                    int iCopy = i;
                    float ax = m_unitsBitweenX;
                    float ay = m_unitsBitweenY;
                    float b = m_playerCount;
                    float posY = centerY + ay;
                    if (m_gridLocal)
                    {
                        if (i >= 2)
                        {
                            iCopy = Mathf.CeilToInt(i / 2f) - 1;
                            posY = centerY - ay;
                        };

                    }
                    print(i + "I");
                    float posX = centerX - ((ax * Mathf.Ceil(b / 2f) - ax) / 2f) + ax * iCopy;

                    if (m_playerCount == 3 && i == 2)
                    {
                        posX = centerX;
                    }

                    Vector2 newPos = new Vector2(posX, posY);

                    RectTransform rectTransform = m_players[i].GetComponent<RectTransform>();
                    if (rectTransform == null)
                        m_players[i].transform.position = newPos;
                    else
                        rectTransform.position = newPos;

                }

            }
            else
            {
                for (int i = 0; i < m_playerCount; i++)
                {
                    float a = m_unitsBitweenX;
                    float b = m_playerCount;
                    float posX = centerX - ((a * b - a) / 2f) + a * i;

                    Vector2 newPos = new Vector2(posX, transform.position.y);

                    RectTransform rectTransform = m_players[i].GetComponent<RectTransform>();
                    if (rectTransform == null)
                        m_players[i].transform.position = newPos;
                    else
                        rectTransform.position = newPos;
                }
            }

        }
    }

}
