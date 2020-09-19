using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitchAsync : MonoBehaviour
{
    private static SceneSwitchAsync m_instance;

    private Animator m_animator;
    private bool m_closingAnimationDone = false;
    private bool m_swtiching = false;

    private void Awake()
    {
        if (m_instance == null)
        {
            m_instance = this;

            SceneLoader.OnLoadSceneAsync += OnLoadScene;

            DontDestroyOnLoad(this);
            m_animator = GetComponent<Animator>();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnDestroy()
    {
        SceneLoader.OnLoadSceneAsync -= OnLoadScene;
    }

    private void OnLoadScene(string scene)
    {
        if (!m_swtiching)
        {
            AsyncOperation operation = SceneManager.LoadSceneAsync(scene);
            StartCoroutine(LoadScene(operation));
        }
    }

    private IEnumerator LoadScene(AsyncOperation operation)
    {

        operation.allowSceneActivation = false;
        m_closingAnimationDone = false;
        m_swtiching = true;

        m_animator.SetTrigger("LoadingScene");

        yield return new WaitUntil(() => m_closingAnimationDone == true);
        operation.allowSceneActivation = true;
        yield return new WaitUntil(() => operation.isDone == true);

        m_animator.SetTrigger("SceneLoaded");
    }

    private void ClosingAnimationDone()
    {
        m_closingAnimationDone = true;
    }

    private void OpeningAnimationDone()
    {
        m_swtiching = false;
        SceneLoader.FireSceneSwitchDone();
    }

}
