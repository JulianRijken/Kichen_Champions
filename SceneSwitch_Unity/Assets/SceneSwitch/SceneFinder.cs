using UnityEngine;
using UnityEngine.SceneManagement;

public static class SceneLoader
{
    public static string GetSceneName(SceneEnumName sceneEnumName)
    {
        SceneNames container = Resources.Load<SceneNames>("ScriptObjects/Scenes/NamedScenes");
        return container.GetSceneName(sceneEnumName);
    }

    public static void LoadScene(SceneEnumName sceneEnumName)
    {
        SceneNames container = Resources.Load<SceneNames>("ScriptObjects/Scenes/NamedScenes");
        string scene = container.GetSceneName(sceneEnumName);
        SceneManager.LoadScene(scene);
    }

    public static AsyncOperation LoadSceneAsync(SceneEnumName sceneEnumName)
    {
        SceneNames container = Resources.Load<SceneNames>("ScriptObjects/Scenes/NamedScenes");
        string scene = container.GetSceneName(sceneEnumName);
        return SceneManager.LoadSceneAsync(scene);
    }

}

public enum SceneEnumName
{
    SceneOne,
    SceneTwo
}

[System.Serializable]
public struct NamedScene
{
    public SceneEnumName sceneEnumName;
    public string sceneName;
}
