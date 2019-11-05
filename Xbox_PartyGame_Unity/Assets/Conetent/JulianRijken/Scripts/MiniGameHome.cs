using Julian.InputSystem;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MiniGameHome : MonoBehaviour
{

    [SerializeField] private TMP_Dropdown m_dropdown;
    [SerializeField] private SceneEnumName[] m_minigameScenes;
    [SerializeField] private TextMeshProUGUI[] m_scoreTexts;
    [SerializeField] private Image[] m_progresImage;
    [SerializeField] private List<PlayerData> m_checkPlayers;
    [SerializeField] private GameObject m_suddenDeathText;
    

    [Header("GameSelect")]
    [SerializeField] Sprite[] m_gameSprites;
    [SerializeField] Image m_gameSpriteImage;
    [SerializeField] private AudioClip tickClip;
    [SerializeField] private AudioSource m_tickSource;
    [SerializeField] private AnimationCurve m_slowDownCurve;
    [SerializeField] private Animator m_animatior;
    [SerializeField] private float m_slowDownTime;
    [SerializeField] private float m_speedMultiplier;
    private float m_swichTimer;
    private float m_swichSpeed;
    private int m_currentSelected;
    private bool gameSelected;


    private List<string> m_minigameScenesString;
    private int m_selectedScene;
    private bool m_sceneSwitched;

    private void Awake()
    {
        SceneLoader.OnSceneSwitched += OnSceneSwitched;

        if (PlayerInputCenter.SelectedPlayerCount < 2)
            SceneLoader.LoadScene(SceneEnumName.ControllerSetup);

        m_sceneSwitched = false;
        m_suddenDeathText.SetActive(false);

    }

    private void OnDestroy()
    {
        SceneLoader.OnSceneSwitched -= OnSceneSwitched;
    }

    private void Start()
    {

        m_minigameScenesString = new List<string>();

        for (int i = 0; i < m_minigameScenes.Length; i++)
        {
            m_minigameScenesString.Add(m_minigameScenes[i].ToString());
        }

        m_dropdown.ClearOptions();
        m_dropdown.AddOptions(m_minigameScenesString);

        m_dropdown.value = 0;


        m_checkPlayers = new List<PlayerData>();
        for (int i = 0; i < m_scoreTexts.Length; i++)
        {
            PlayerData playerData = GameManager.ScoreCenter.GetPlayerData(i);
            if (playerData != null)
            {
                if (playerData.m_score >= GameManager.ScoreCenter.GetGameLength())
                    m_checkPlayers.Add(playerData);


                m_scoreTexts[i].text = playerData.m_score + " / " + GameManager.ScoreCenter.GetGameLength().ToString();
                m_progresImage[i].fillAmount = 0;
            }
        }

        CheckWinner(m_checkPlayers);

        m_swichTimer = 0;
        gameSelected = false;
        m_currentSelected = Random.Range(0, m_minigameScenes.Length);
    }

    private void Update()
    {

        if (m_sceneSwitched)
        {
            for (int i = 0; i < m_scoreTexts.Length; i++)
            {
                PlayerData playerData = GameManager.ScoreCenter.GetPlayerData(i);
                if (playerData != null)
                {
                    m_progresImage[i].fillAmount = Mathf.MoveTowards(m_progresImage[i].fillAmount, Mathf.Clamp01(playerData.m_score / (float)GameManager.ScoreCenter.GetGameLength()), Time.deltaTime * 0.5f);
                }
            }
        }

        if (!gameSelected)
        {
            m_swichTimer += Time.deltaTime / m_slowDownTime;
            m_swichTimer = Mathf.Clamp01(m_swichTimer);
            m_animatior.SetFloat("Progress", m_swichTimer);


            if (m_swichTimer == 1)
            {
                SwitchGame();
                gameSelected = true;
                m_animatior.SetTrigger("GameSelected");
            }

            m_swichSpeed += Time.deltaTime * m_slowDownCurve.Evaluate(m_swichTimer) * m_speedMultiplier;

            if(m_swichSpeed >= 1f)
            {
                SwitchGame();
                m_swichSpeed = m_swichSpeed - 1f;
            }
        }

    }

    private void SwitchGame()
    {
        m_currentSelected++;
        if (m_currentSelected >= m_gameSprites.Length)
            m_currentSelected = 0;
        m_gameSpriteImage.sprite = m_gameSprites[m_currentSelected];
        m_tickSource.PlayOneShot(tickClip);
        m_animatior.SetTrigger("GameSwitched");
    }

    public void StartCurrentGame()
    {
        SceneLoader.LoadSceneAsync(m_minigameScenes[m_currentSelected]);
    }



    private void OnSceneSwitched()
    {
        m_sceneSwitched = true;
    }


    private void CheckWinner(List<PlayerData> playerData)
    {



        if (playerData.Count > 1)
        {
            PlayerData bestPlayer;
            int bestPlayerScore = 0;
            for (int i = 0; i < playerData.Count; i++)
            {
                if (playerData[i].m_player > bestPlayerScore)
                {
                    bestPlayer = playerData[i];
                    bestPlayerScore = playerData[i].m_score;
                }
            }

            List<PlayerData> bestPlayers = new List<PlayerData>();
            for (int i = 0; i < playerData.Count; i++)
            {
                if (playerData[i].m_score == bestPlayerScore)
                    bestPlayers.Add(playerData[i]);


            }

            if (bestPlayers.Count > 1)
            {
                Debug.Log("SuddenDeath");
                m_suddenDeathText.SetActive(true);
            }
            else if(bestPlayers.Count == 1)
            {
                OnGameFinish(bestPlayers[0]);
            }
        }
        else if (playerData.Count == 1)
            OnGameFinish(playerData[0]);
    }

    private void OnGameFinish(PlayerData winner)
    {
        GameManager.ScoreCenter.SetWinningPlayer(winner);
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
