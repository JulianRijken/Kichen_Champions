using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Julian.InputSystem;
using UnityEngine.InputSystem;

public class PlayerCereal : MonoBehaviour
{
    [SerializeField] private int m_player;

    [Header("Box")]
    [SerializeField] private Transform m_cerealBox;
    [SerializeField] private Transform m_cerealSpawnPoint;
    [SerializeField] private GameObject m_cerealPrefab;

    [Header("Bole")]
    [SerializeField] private Rigidbody2D m_bole;
    [SerializeField] private float m_swayScale;
    [SerializeField] private float m_swaySpeed;
    [SerializeField] private float m_noiseSwayScale;
    [SerializeField] private float m_noiseSwaySpeed;

    private Vector2 m_MovementInput;
    private Vector3 m_boleStartPos;

    void Start()
    {
        PlayerInputCenter.PlayerInputEvents[m_player].OnMove += HandeMovement;

        m_boleStartPos = m_bole.transform.position;
    }

    private void OnDestroy()
    {
        PlayerInputCenter.PlayerInputEvents[m_player].OnMove -= HandeMovement;
    }

    private void HandeMovement(InputAction.CallbackContext conext)
    {
        m_MovementInput = conext.ReadValue<Vector2>();
    }

   
    private void Update()
    {
        Instantiate(m_cerealPrefab, m_cerealSpawnPoint.transform.position, m_cerealSpawnPoint.transform.rotation);

    }

    private void FixedUpdate()
    {
        MoveBole();

    }

    private void MoveBole()
    {
        Vector3 input = new Vector3(m_MovementInput.x, 0, 0);

        input.x *= m_swayScale;

        input.x += (Mathf.PerlinNoise(Time.time * m_noiseSwaySpeed, Time.time * m_noiseSwaySpeed) - 0.5f) * m_noiseSwayScale;

        input.x = Mathf.Clamp(input.x, -m_swayScale, m_swayScale);

        Vector3 toPos = Vector3.Lerp(m_boleStartPos, m_boleStartPos + input, 1);
        m_bole.MovePosition(Vector3.Lerp(m_bole.transform.position, toPos, Time.deltaTime * m_swaySpeed));

        Debug.DrawLine(m_bole.transform.position, m_boleStartPos);
    }
}
