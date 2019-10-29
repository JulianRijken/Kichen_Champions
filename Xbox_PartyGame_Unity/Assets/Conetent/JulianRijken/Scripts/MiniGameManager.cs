using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Julian.InputSystem;
using UnityEditor;
using UnityEngine.SceneManagement;

public class MiniGameManager : MonoBehaviour
{
    public static MiniGameManager Instance { get; private set; }

    [Header("Timer")]
    [SerializeField] private float m_minigameTime;

    [Header("Players")]
    [SerializeField] private GameObject[] m_players;
    [SerializeField] private int m_playerCount;

    [Header("Alignment")]
    [SerializeField] private bool m_align;
    [SerializeField] private float m_unitsBitween;

    private bool[] m_playersDone;
    private bool timerDone;
    private float timer;


    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);


        m_playerCount = PlayerInputCenter.SelectedPlayerCount;

        if(m_playerCount < 2)      
            SceneManager.LoadScene(SceneLoader.GetSceneName(SceneEnumName.ControllerSetup));       
        else   
            ResetPlayers();

        m_playersDone = new bool[m_playerCount];
        for (int i = 0; i < m_playersDone.Length; i++)
        {
            m_playersDone[i] = false;
        }
    }

    private void Start()
    {
        timer = m_minigameTime;
        timerDone = false;
    }

    private void Update()
    {
        if (!timerDone)
        {
            timer -= Time.deltaTime;

            if (timer <= 0)
            {
                timer = 0;
                timerDone = true;
                FireTimerUpdate(timer);
                FireTimerOver();
                OnTimerOver();
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
        if (!timerDone)
            FireTimerUpdate(timer);
    }



    [ContextMenu("ResetPlayers")]
    private void ResetPlayers()
    {
        for (int i = 0; i < m_players.Length; i++)
            m_players[i].SetActive(false);

        for (int i = 0; i < m_playerCount; i++)
            m_players[i].SetActive(true);

        if (m_align)
        {
            float centerX = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width / 2, 0, 0)).x;

            for (int i = 0; i < m_playerCount; i++)
            {
                float a = m_unitsBitween;
                float b = m_playerCount;

                float posX = centerX - ((a * b - a) / 2f) + a * i;

                Vector2 newPos = new Vector2(posX, transform.position.y);

                if(m_players[i].GetComponent<RectTransform>() == null)
                    m_players[i].transform.position = newPos;
            }
        }
    }


    public void FireTimerOver()
    {
        OnTimerDone?.Invoke();
        Debug.LogWarning("ZORG DAT JE MET FIND SCENE GEWOON LOAD SCENE KAN DOEN");
        SceneManager.LoadScene(SceneLoader.GetSceneName(SceneEnumName.MinigamesHome));
    }
    public delegate void TimerDoneAction();
    public event TimerDoneAction OnTimerDone;

    public void FireTimerUpdate(float time)
    {
        OnTimerUpdate?.Invoke(time);
    }
    public delegate void TimerUpdateAction(float time);
    public event TimerUpdateAction OnTimerUpdate;

}
