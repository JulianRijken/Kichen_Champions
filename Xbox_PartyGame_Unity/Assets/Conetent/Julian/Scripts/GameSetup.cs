using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class GameSetup : MonoBehaviour
{
    [SerializeField] private GameObject[] m_connectedIcons;
    [SerializeField] private TextMeshProUGUI infoText;
    [SerializeField] private string notEnoughControllersText;
    [SerializeField] private string startText;
    private int m_connectedPlayers;


    private void Update()
    {
        //DoPlayerCheck();
        
        if(m_connectedPlayers <= 1)
        {
            infoText.text = notEnoughControllersText;
        }
        else
        {
            infoText.text = startText;
        }

        if (Input.GetKeyDown(KeyCode.W))
            StartGame();

    }

    private void DoPlayerCheck()
    {
        m_connectedPlayers = InputDevice.all.Count;


        for (int i = 0; i < m_connectedIcons.Length; i++)
        {
            m_connectedIcons[i].SetActive(false);
        }

        for (int i = 0; i < m_connectedPlayers; i++)
        {
            m_connectedIcons[i].SetActive(true);
        }

        Debug.Log("Player Check: Input Count = " + InputDevice.all.Count);
    }

    private void StartGame()
    {
        GameManager gameManager = GameManager.Instance;

        gameManager.ConnectedPlayersAtStart = m_connectedPlayers;
        Debug.Log("Load Scene with player count: " + gameManager.ConnectedPlayersAtStart);
    }
}
