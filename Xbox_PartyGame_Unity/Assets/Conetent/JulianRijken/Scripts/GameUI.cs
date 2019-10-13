using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timerText;

    private void Awake()
    {
        MiniGameManager.Instance.OnTimerUpdate += HandleTimer;
    }

    private void OnDestroy()
    {
        MiniGameManager.Instance.OnTimerUpdate -= HandleTimer;
    }

    private void HandleTimer(float time)
    {
        if(timerText != null)
        timerText.text = Mathf.Round(time).ToString();
    }

}
