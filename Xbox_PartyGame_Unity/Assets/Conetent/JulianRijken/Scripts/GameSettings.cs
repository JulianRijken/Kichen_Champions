using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Julian.InputSystem;

public class GameSettings : MonoBehaviour
{

    [SerializeField] private Slider m_lenghSlider;
    [SerializeField] private float m_lenghMultiply;
    [SerializeField] private TextMeshProUGUI m_sliderValueText;

    private int m_selectedValue;

    private void Awake()
    {
        if (PlayerInputCenter.SelectedPlayerCount < 2)
            SceneLoader.LoadScene(SceneEnumName.ControllerSetup);
    }

    private void Start()
    {
        if (m_lenghSlider != null)
        {
            m_lenghSlider.value = GameManager.ScoreCenter.GetGameLength() / m_lenghMultiply;
        }
    }

    private void LateUpdate()
    {
        if (m_lenghSlider != null && m_sliderValueText != null)
        {
            if (m_lenghSlider.value == 0)
            {
                m_selectedValue = 1;
                m_sliderValueText.text = 1+"";
            }
            else
            {
                m_selectedValue = Mathf.RoundToInt(m_lenghSlider.value * m_lenghMultiply);
                m_sliderValueText.text = m_selectedValue.ToString();
            }
        }
    }

    public void StartGame()
    {
        GameManager.ScoreCenter.SetGameLength(m_selectedValue);
        SceneLoader.LoadSceneAsync(SceneEnumName.MinigamesHome);
    }
}
