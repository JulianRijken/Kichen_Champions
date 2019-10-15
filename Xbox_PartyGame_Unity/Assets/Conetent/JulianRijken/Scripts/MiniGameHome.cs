using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class MiniGameHome : MonoBehaviour
{

    [SerializeField] private TMP_Dropdown m_dropdown;
    [SerializeField] private List<SceneEnumName> minigameScenes;
    private List<string> minigameScenesString;

    private int m_selectedScene;

    void Start()
    {

        minigameScenesString = new List<string>();

        for (int i = 0; i < minigameScenes.Count; i++)
        {
            minigameScenesString.Add(minigameScenes[i].ToString());
        }

        m_dropdown.ClearOptions();
        m_dropdown.AddOptions(minigameScenesString);

        m_dropdown.value = 0;

    }


    public void OnDropdownChanged(int option)
    {
        Debug.Log("Selected Scene: " + minigameScenes[option]);
        m_selectedScene = option;
    }

    public void LoadScene()
    {
        SceneManager.LoadScene(SceneFinder.GetSceneName(minigameScenes[m_selectedScene]));
    }
}
