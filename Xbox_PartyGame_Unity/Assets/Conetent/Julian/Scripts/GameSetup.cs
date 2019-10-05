using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using TMPro;
using UnityEngine.SceneManagement;
using Julian.InputSystem;

public class GameSetup : MonoBehaviour
{
    [SerializeField] private Button[] startButtons;
    [SerializeField] private TextMeshProUGUI infoText;
    [SerializeField] private string notEnoughControllersText;
    [SerializeField] private string startText;

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
            PlayerInputCenter.Instance.ResetDevices();    
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
                infoText.text = startText;
                break;

            case 3:
                startButtons[0].interactable = true;
                startButtons[1].interactable = true;
                startButtons[1].Select();
                infoText.text = startText;
                break;

            case 4:
                startButtons[0].interactable = true;
                startButtons[1].interactable = true;
                startButtons[2].interactable = true;
                startButtons[2].Select();
                infoText.text = startText;
                break;

            default:
                infoText.text = notEnoughControllersText;
                break;
        }
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene(0);
    }


    public void StartGame(int playerCount)
    {
        SceneManager.LoadScene(2);
        PlayerInputCenter.SelectedPlayerCount = playerCount;
    }



}
