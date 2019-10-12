using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Julian.InputSystem;
using UnityEngine.InputSystem;

public class PlayerCereal : MonoBehaviour
{
    [SerializeField] private int m_player;

    [Header("Box")]
    [SerializeField] private Rigidbody2D m_cerealBox;
    [SerializeField] private Transform m_cerealSpawnPoint;
    [SerializeField] private string m_cerialName;
    [SerializeField] private float m_boxShakeAmmount;
    [SerializeField] private float m_boxShakeStopSpeed;
    [SerializeField] private float m_boxShakeSpeed;
    private float m_boxShake;

    [Header("Bole")]
    [SerializeField] private Rigidbody2D m_bole;
    [SerializeField] private LayerMask m_cerialLayerMask;
    [SerializeField] private float m_boleCheckRadius;
    [SerializeField] private Vector2 m_boleCheckCenter;
    [SerializeField] private float m_swayScale;
    [SerializeField] private float m_swaySpeed;
    [SerializeField] private float m_noiseSwayScale;
    [SerializeField] private float m_noiseSwaySpeed;

    private Vector2 m_MovementInput;
    private Vector3 m_boleStartPos;
    private Vector3 m_boxStartPos;
    private float m_timer;

    void Start()
    {
        PlayerInputCenter.PlayerInputEvents[m_player].OnMove += HandeMovement;
        PlayerInputCenter.PlayerInputEvents[m_player].OnButtonSouth += HandelButton;

        m_boxShake = 0;
        m_boleStartPos = m_bole.transform.position;
        m_boxStartPos = m_cerealBox.transform.position;

        m_timer = Random.Range(0f, 100f);
    }

    private void OnDestroy()
    {
        PlayerInputCenter.PlayerInputEvents[m_player].OnMove -= HandeMovement;
        PlayerInputCenter.PlayerInputEvents[m_player].OnButtonSouth -= HandelButton;
    }

    private void HandeMovement(InputAction.CallbackContext conext)
    {
        m_MovementInput = conext.ReadValue<Vector2>();
    }
    
    private void HandelButton(InputAction.CallbackContext conext)
    {
        if (conext.performed)
        {
            ObjectPooler.SpawnObject(m_cerialName, m_cerealSpawnPoint.transform.position, m_cerealSpawnPoint.transform.rotation,true);
            m_boxShake = m_boxShakeAmmount;
        }
    }



    private void MoveBox()
    {
        m_boxShake -= Time.deltaTime * m_boxShakeStopSpeed;
        m_boxShake = Mathf.Clamp(m_boxShake,0, Mathf.Infinity);
        Vector3 addedMove = new Vector3(Mathf.PerlinNoise(m_timer * m_boxShakeSpeed, 0) - 0.5f, 0, 0);
        addedMove *= m_boxShake;
        m_cerealBox.MovePosition(m_boxStartPos + addedMove);
    }

    private void Update()
    {
        m_timer += Time.deltaTime;

        Collider2D[] colliders = Physics2D.OverlapCircleAll((Vector2)m_bole.transform.position + m_boleCheckCenter, m_boleCheckRadius, m_cerialLayerMask);
        Debug.Log(colliders.Length);
    }

    private void FixedUpdate()
    {
        MoveBole();
        MoveBox();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(0, 1f, 0, 0.5f);
        Gizmos.DrawSphere((Vector2)m_bole.transform.position + m_boleCheckCenter, m_boleCheckRadius);
    }



    private void MoveBole()
    {
        Vector3 input = new Vector3(m_MovementInput.x, 0, 0);

        input.x *= m_swayScale;

        input.x += (Mathf.PerlinNoise(m_timer * m_noiseSwaySpeed, m_timer * m_noiseSwaySpeed) - 0.5f) * m_noiseSwayScale;

        input.x = Mathf.Clamp(input.x, -m_swayScale, m_swayScale);

        Vector3 toPos = Vector3.Lerp(m_boleStartPos, m_boleStartPos + input, 1);
        m_bole.MovePosition(Vector3.Lerp(m_bole.transform.position, toPos, Time.deltaTime * m_swaySpeed));

        Debug.DrawLine(m_bole.transform.position, m_boleStartPos);
    }
}
