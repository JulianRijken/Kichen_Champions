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

    public static void LoadSceneAsync(SceneEnumName sceneEnumName)
    {
        SceneNames container = Resources.Load<SceneNames>("ScriptObjects/Scenes/NamedScenes");
        string scene = container.GetSceneName(sceneEnumName);
        OnLoadSceneAsync?.Invoke(scene);
    }

    public delegate void LoadSceneAsyncAction(string scene);
    public static event LoadSceneAsyncAction OnLoadSceneAsync;

}

public enum SceneEnumName
{
    MainMenu,
    ControllerSetup,
    MinigamesHome,
    Cereal,
    BeatTheMeat
}

[System.Serializable]
public struct NamedScene
{
    public SceneEnumName sceneEnumName;
    public string sceneName;
}
