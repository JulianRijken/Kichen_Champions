using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class EindScreen : MonoBehaviour
{

    [SerializeField] private Sprite[] winnerSprites;
    [SerializeField] private Image winnerImage;

    private Controls controls;

    private void Awake()
    {
        controls = new Controls();
        controls.Player.Start.performed += Exit;
    }

    private void OnEnable()
    {
        controls.Enable();
    }

    private void OnDestroy()
    {
        controls.Player.Start.performed -= Exit;
        controls.Disable();
    }

    private void Start()
    {
        PlayerData winningPlayer = GameManager.ScoreCenter.GetWinningPlayer();
        if (winningPlayer != null)
        {
            if (winningPlayer.m_player < winnerSprites.Length)
                winnerImage.sprite = winnerSprites[winningPlayer.m_player];
        }
    }

    private void Exit(InputAction.CallbackContext context)
    {
        SceneLoader.LoadSceneAsync(SceneEnumName.MainMenu);
    }

}
