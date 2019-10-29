using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NamedScenes", menuName = "New NamedScenes")]
public class SceneNames : ScriptableObject
{
    [SerializeField]
    private NamedScene[] m_namedScenes;

    public string GetSceneName(SceneEnumName sceneEnumName)
    {
        for (int i = 0; i < m_namedScenes.Length; i++)
        {
            NamedScene sceneContainer = m_namedScenes[i];
            if (sceneContainer.sceneEnumName == sceneEnumName)
                return sceneContainer.sceneName;
        }

        Debug.LogWarning("Scene Does Not Exist In Container");
        return "null";
    }

}
