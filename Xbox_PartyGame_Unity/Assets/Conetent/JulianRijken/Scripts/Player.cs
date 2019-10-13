using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerInput))]
public class Player : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI m_playerNumberText;
    [SerializeField] SpriteRenderer m_spriteRenderer;
    [SerializeField] PlayerInput m_playerInput;

    private Vector2 m_moveInput;
    private GameManager m_gameManager;

    private void Awake()
    {
        var player = m_playerInput.user;
        if (!player.valid)
        {
            Destroy(gameObject);
        }
        else
        {
            m_gameManager = GameManager.Instance;
            m_gameManager.AddPlayer(m_playerInput.user.index);
        }
       
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        m_moveInput = context.ReadValue<Vector2>();
    }


    private void Start()
    {
        m_playerNumberText.text = m_playerInput.user.index.ToString();

    }

    private void Update()
    {
        if (m_moveInput.magnitude > 0)
        {
            m_spriteRenderer.color = Color.green;
        }
        else
        {
            m_spriteRenderer.color = Color.red;
        }

        transform.position += (Vector3)m_moveInput * 10 * Time.deltaTime;

        m_gameManager.GetPlayerData(m_playerInput.user.index).m_score += 1;
    }
}
