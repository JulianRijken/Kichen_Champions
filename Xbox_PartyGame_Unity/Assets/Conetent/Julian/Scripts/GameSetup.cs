using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using UnityEngine.SceneManagement;
using Julian.InputSystem;

public class GameSetup : MonoBehaviour
{
    [SerializeField] private GameObject[] m_connectedIcons;
    [SerializeField] private TextMeshProUGUI infoText;
    [SerializeField] private string notEnoughControllersText;
    [SerializeField] private string startText;
    private int m_connectedPlayers;


    private void Update()
    {

        m_connectedPlayers = PlayerInputCenter.PlayerCount;

        if (InputDevice.all.Count != m_connectedPlayers)
            PlayerInputCenter.Instance.ResetDevices();

        if (m_connectedPlayers <= 1)
        {
            infoText.text = notEnoughControllersText;
        }
        else
        {
            infoText.text = startText;
        }


    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }



}
