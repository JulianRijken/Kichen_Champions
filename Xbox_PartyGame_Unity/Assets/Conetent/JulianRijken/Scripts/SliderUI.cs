using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SliderUI : MonoBehaviour
{
    [SerializeField] private Animator timerSlider;

    private void Awake()
    {
        MiniGameManager.Instance.OnTimerUpdate += HandleTimer;
    }

    private void OnDestroy()
    {
        MiniGameManager.Instance.OnTimerUpdate -= HandleTimer;
    }

    private void HandleTimer(float procent,float time)
    {
        timerSlider.SetFloat("Procent", procent);
    }

}
