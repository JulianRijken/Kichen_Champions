using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTimer : MonoBehaviour
{

    [SerializeField] private float gameTime;
   
    public static GameTimer Instance { get; private set; }

    private bool timerDone;
    private float timer;


    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    private void Start()
    {
        timer = gameTime;
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
            }
        }
    }

    private void LateUpdate()
    {
        if (!timerDone)
            FireTimerUpdate(timer);   
    }

    public void FireTimerDone()
    {
        OnTimerDone?.Invoke();
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
