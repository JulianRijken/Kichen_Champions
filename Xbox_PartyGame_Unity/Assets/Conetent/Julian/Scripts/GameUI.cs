using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timerText;

    private void Awake()
    {
        GameTimer.Instance.OnTimerUpdate += HandleTimer;
    }

    private void OnDestroy()
    {
        GameTimer.Instance.OnTimerUpdate -= HandleTimer;
    }

    private void HandleTimer(float time)
    {
        timerText.text = Mathf.Round(time).ToString();
    }

}
