using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Julian.InputSystem;
using UnityEditor;

public class MiniGameManager : MonoBehaviour
{
    public static MiniGameManager Instance { get; private set; }

    [SerializeField] private float m_minigameTime;

    private bool[] m_playersDone;
    private bool m_IsTimerDone;
    private float m_timer;


    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);

        if(PlayerInputCenter.SelectedPlayerCount < 2)      
            SceneLoader.LoadScene(SceneEnumName.ControllerSetup);

        m_playersDone = new bool[PlayerInputCenter.SelectedPlayerCount];

        for (int i = 0; i < m_playersDone.Length; i++)
        {
            m_playersDone[i] = false;
        }
    }

    private void Start()
    {
        m_timer = 0;
        m_IsTimerDone = false;
    }

    private void Update()
    {
        if (!m_IsTimerDone)
        {
            m_timer += Time.deltaTime;

            if (m_timer >= m_minigameTime)
            {
                m_timer = m_minigameTime;
                m_IsTimerDone = true;
                OnTimerOver();
                UpdateTimer();
                FireTimerOver();
            }
        }
    }

    private void OnTimerOver()
    {
        for (int i = 0; i < m_playersDone.Length; i++)
        {
            if(m_playersDone[i] == true)
            {
                GameManager.ScoreCenter.AddScore(i, 1);
            }
        }
    }

    public static void SetPlayerDone(int player)
    {
        Instance.m_playersDone[player] = true;
    }

    private void LateUpdate()
    {
        if (!m_IsTimerDone)
            UpdateTimer();
    }


    private void UpdateTimer()
    {
        FireTimerUpdate(Mathf.Clamp01(m_timer / m_minigameTime), m_timer);
    }


    public void FireTimerOver()
    {
        OnTimerDone?.Invoke();
        SceneLoader.LoadSceneAsync(SceneEnumName.MinigamesHome);
    }
    public delegate void TimerDoneAction();
    public event TimerDoneAction OnTimerDone;

    public void FireTimerUpdate(float procent,float time)
    {
        OnTimerUpdate?.Invoke(procent, time);
    }
    public delegate void TimerUpdateAction(float procent, float time);
    public event TimerUpdateAction OnTimerUpdate;

}
