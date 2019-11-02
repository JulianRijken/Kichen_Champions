using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MiniGameHome : MonoBehaviour
{

    [SerializeField] private TMP_Dropdown m_dropdown;
    [SerializeField] private List<SceneEnumName> minigameScenes;
    [SerializeField] private TextMeshProUGUI[] m_scoreTexts;

    private List<string> _minigameScenesString;
    private int m_selectedScene;

    void Start()
    {

        _minigameScenesString = new List<string>();

        for (int i = 0; i < minigameScenes.Count; i++)
        {
            _minigameScenesString.Add(minigameScenes[i].ToString());
        }

        m_dropdown.ClearOptions();
        m_dropdown.AddOptions(_minigameScenesString);

        m_dropdown.value = 0;

        for (int i = 0; i < m_scoreTexts.Length; i++)
        {
            PlayerData playerData = GameManager.ScoreCenter.GetPlayerData(i);
            if (playerData != null)
                m_scoreTexts[i].text = playerData.m_score.ToString();
            else
                m_scoreTexts[i].text = "X";
        }

    }


    public void OnDropdownChanged(int option)
    {
        Debug.Log("Selected Scene: " + minigameScenes[option]);
        m_selectedScene = option;
    }

    public void LoadScene()
    {
        SceneLoader.LoadSceneAsync(minigameScenes[m_selectedScene]);
    }
}
