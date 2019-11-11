using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutTape : MonoBehaviour
{

    [SerializeField] private float m_startSpeed;
    [SerializeField] private float m_accelerateSpeed;

    private float m_speed;
    private float m_length;

    private void Start()
    {
        m_speed = m_startSpeed;
        Destroy(gameObject,5f);
    }

    void Update()
    {
        m_speed += Time.deltaTime * m_accelerateSpeed;
        transform.position += Vector3.down * m_speed * Time.deltaTime;
    }
}
