using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ButtonSound : MonoBehaviour
{

    [SerializeField] private AudioClip m_onClickClip;
    [SerializeField] private AudioClip m_onSelectClip;
    [SerializeField] [Range(0f,1f)] private float m_volume = 1f;

    private AudioSource m_audioSource;
    private Button m_button;

    private void Start()
    {
        m_audioSource = gameObject.AddComponent<AudioSource>();
        m_button = GetComponent<Button>();
        m_audioSource.volume = m_volume;

        m_button.onClick.AddListener(() => OnClick());
    }

    private void OnDestroy()
    {
        m_button.onClick.RemoveListener(() => OnClick());
    }

    private void OnClick()
    {
        if(m_onClickClip != null && m_audioSource != null)
            m_audioSource.PlayOneShot(m_onClickClip);
    }
}
