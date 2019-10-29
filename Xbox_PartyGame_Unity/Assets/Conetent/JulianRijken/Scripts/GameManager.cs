using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    private NotificationCenter m_notificationCenter;
    private ScoreCenter m_scoreCenter;

    public static GameManager m_instance { get; private set; }
    public static NotificationCenter NotificationCenter { get => m_instance.m_notificationCenter; }
    public static ScoreCenter ScoreCenter { get => m_instance.m_scoreCenter; }


    private void Awake()
    {
        if (m_instance == null)
        {
            m_instance = this;
            DontDestroyOnLoad(m_instance.gameObject);

            m_notificationCenter = new NotificationCenter();
            m_scoreCenter = new ScoreCenter();
        }
        else if (this != m_instance)
        {
            Destroy(gameObject);
        }
    }

}

