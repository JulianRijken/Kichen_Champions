using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{

    private NotificationCenter m_notificationCenter;
    private ScoreCenter m_scoreCenter;

    public static GameManager m_instance { get; private set; }
    public static NotificationCenter NotificationCenter { get => m_instance.m_notificationCenter; }
    public static ScoreCenter ScoreCenter { get => m_instance.m_scoreCenter; }


    private Controls controls;


    private void Awake()
    {
        if (m_instance == null)
        {
            m_instance = this;
            DontDestroyOnLoad(m_instance.gameObject);

            m_notificationCenter = new NotificationCenter();
            m_scoreCenter = new ScoreCenter();

            controls = new Controls();

            controls.Enable();

            controls.Player.ExitToMenu.performed += OnExitToMenu;

            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        else if (this != m_instance)
        {
            Destroy(gameObject);
        }
    }

    private void OnExitToMenu(InputAction.CallbackContext context)
    {
        SceneLoader.LoadSceneAsync(SceneEnumName.MainMenu);
    }

}

