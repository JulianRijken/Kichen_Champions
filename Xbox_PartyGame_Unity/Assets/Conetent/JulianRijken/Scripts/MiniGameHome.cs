using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class MiniGameHome : MonoBehaviour
{

    [SerializeField] private TMP_Dropdown m_dropdown;
    [SerializeField] private List<string> minigameScenes;

    private int m_selectedScene;

    void Start()
    {
        m_dropdown.ClearOptions();
        m_dropdown.AddOptions(minigameScenes);
        m_dropdown.value = 0;

    }


    public void OnDropdownChanged(int option)
    {
        Debug.Log("Selected Scene: " + minigameScenes[option]);
        m_selectedScene = option;
    }

    public void LoadScene()
    {
        SceneManager.LoadScene(minigameScenes[m_selectedScene]);
    }
}
