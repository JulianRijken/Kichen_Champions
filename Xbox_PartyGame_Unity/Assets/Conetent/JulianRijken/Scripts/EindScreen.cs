using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EindScreen : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI winnerText;

    private void Start()
    {
        PlayerData winningPlayer = GameManager.ScoreCenter.GetWinningPlayer();
        if (winningPlayer != null)
        {
            int winnerNumber = winningPlayer.m_player + 1;
            winnerText.text = "Player " + winnerNumber + " Wint!";
        }
    }

    public void Exit()
    {
        SceneLoader.LoadSceneAsync(SceneEnumName.MainMenu);
    }

}
