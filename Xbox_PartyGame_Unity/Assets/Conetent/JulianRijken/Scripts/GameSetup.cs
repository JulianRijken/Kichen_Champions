using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using TMPro;
using Julian.InputSystem;

public class GameSetup : MonoBehaviour
{
    [SerializeField] private Button[] startButtons;
    [SerializeField] private Button backButton;
    [SerializeField] private SceneEnumName m_minigameHomeScene;
    
    private int m_connectedPlayers;

    private void Start()
    {
        PlayerInputCenter.Instance.OnDevicesReset += RefreshButtons;
        RefreshButtons();
    }

    private void OnDestroy()
    {
        PlayerInputCenter.Instance.OnDevicesReset -= RefreshButtons;
    }

    private void Update()
    {
        m_connectedPlayers = PlayerInputCenter.PlayerEventsCount;
        if (InputDevice.all.Count != m_connectedPlayers)
        {
            Debug.Log("Devices count change, All count: " + InputDevice.all.Count.ToString() + " m_connectedPlayers: " + m_connectedPlayers);
            PlayerInputCenter.Instance.ResetDevices();
            backButton.Select();
        }
    }

    private void RefreshButtons()
    {
        foreach (Button button in startButtons) button.interactable = false;

        m_connectedPlayers = PlayerInputCenter.PlayerEventsCount;

        switch (m_connectedPlayers)
        {
            case 2:
                startButtons[0].interactable = true;
                startButtons[0].Select();
                break;

            case 3:
                startButtons[0].interactable = true;
                startButtons[1].interactable = true;
                startButtons[1].Select();
                break;

            case 4:
                startButtons[0].interactable = true;
                startButtons[1].interactable = true;
                startButtons[2].interactable = true;
                startButtons[2].Select();
                break;

            //default:
            //    break;
        }
    }

    public void ReturnToMenu()
    {
        SceneLoader.LoadSceneAsync(SceneEnumName.MainMenu);
    }


    public void StartGame(int playerCount)
    {
        GameManager.ScoreCenter.CreateNewPlayerData(playerCount);
        GameManager.NotificationCenter.FireGameStart(playerCount);
        SceneLoader.LoadSceneAsync(m_minigameHomeScene);
        PlayerInputCenter.SelectedPlayerCount = playerCount;
    }



}
