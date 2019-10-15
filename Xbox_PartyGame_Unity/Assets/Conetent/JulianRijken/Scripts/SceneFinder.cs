using UnityEngine;

[CreateAssetMenu(fileName = "NamedScenes", menuName = "New NamedScenes")]
public class NamedScenes : ScriptableObject
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

public static class SceneFinder
{
    public static string GetSceneName(SceneEnumName sceneEnumName)
    {
        NamedScenes container = Resources.Load<NamedScenes>("ScriptObjects/Scenes/NamedScenes");
        return container.GetSceneName(sceneEnumName);
    }
}

public enum SceneEnumName
{
   MainMenu,
   ControllerSetup,
   MinigamesHome,
   Cereal
}

[System.Serializable]
public struct NamedScene
{
    public SceneEnumName sceneEnumName;
    public string sceneName;
}
