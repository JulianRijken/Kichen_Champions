using Julian.InputSystem;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MiniGameHome : MonoBehaviour
{

    [SerializeField] private TMP_Dropdown m_dropdown;
    [SerializeField] private List<SceneEnumName> m_minigameScenes;
    [SerializeField] private TextMeshProUGUI[] m_scoreTexts;
    [SerializeField] private Image[] m_progresImage;

    private List<string> m_minigameScenesString;
    private int m_selectedScene;

    private void Awake()
    {
        if (PlayerInputCenter.SelectedPlayerCount < 2)
            SceneLoader.LoadScene(SceneEnumName.ControllerSetup);
    }

    private void Start()
    {

        m_minigameScenesString = new List<string>();

        for (int i = 0; i < m_minigameScenes.Count; i++)
        {
            m_minigameScenesString.Add(m_minigameScenes[i].ToString());
        }

        m_dropdown.ClearOptions();
        m_dropdown.AddOptions(m_minigameScenesString);

        m_dropdown.value = 0;

        for (int i = 0; i < m_scoreTexts.Length; i++)
        {
            PlayerData playerData = GameManager.ScoreCenter.GetPlayerData(i);
            if (playerData != null)
            {
                if (playerData.m_score == GameManager.ScoreCenter.GetGameLength())
                    OnGameFinish();

                m_scoreTexts[i].text = playerData.m_score + " / " + GameManager.ScoreCenter.GetGameLength().ToString();
                m_progresImage[i].fillAmount = Mathf.Clamp01(playerData.m_score / (float)GameManager.ScoreCenter.GetGameLength());
            }
        }

    }

    private void OnGameFinish()
    {
        SceneLoader.LoadScene(SceneEnumName.EindScreen);
    }


    public void OnDropdownChanged(int option)
    {
        Debug.Log("Selected Scene: " + m_minigameScenes[option]);
        m_selectedScene = option;
    }

    public void LoadScene()
    {
        SceneLoader.LoadSceneAsync(m_minigameScenes[m_selectedScene]);
    }
}
