using UnityEngine;

public static class SceneFinder
{
    public static string GetSceneName(SceneEnumName sceneEnumName)
    {
        SceneNames container = Resources.Load<SceneNames>("ScriptObjects/Scenes/NamedScenes");
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
