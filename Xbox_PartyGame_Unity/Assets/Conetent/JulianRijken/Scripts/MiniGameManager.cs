using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Julian.InputSystem;
using UnityEditor;
using UnityEngine.SceneManagement;

public class MiniGameManager : MonoBehaviour
{
    public static MiniGameManager Instance { get; private set; }

    [SerializeField] private float m_minigameTime;
    [SerializeField] private float m_unitsBitween;
    [SerializeField] private int m_playerCount;
    [SerializeField] private Transform[] m_players;

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
            AlignPlayers();
        

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
                FireTimerDone();
            }
        }
    }

    private void LateUpdate()
    {
        if (!timerDone)
            FireTimerUpdate(timer);
    }



    [ContextMenu("Align")]
    private void AlignPlayers()
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


    public void FireTimerDone()
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
