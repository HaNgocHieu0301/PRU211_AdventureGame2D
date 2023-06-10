using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

public class ConfigBuild
{
    [MenuItem("Open Scene/Loading Scene")]
    public static void OpenSceneGamePlay()
    {
        string localPath = "Assets/PRU211_FinalProject/Scenes/LoadingScene.unity";
        EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo();
        EditorSceneManager.OpenScene(localPath);
    }

    [MenuItem("Open Scene/Start Game Scene")]
    public static void OpenSceneCreatLevel()
    {
        string localPath = "Assets/PRU211_FinalProject/Scenes/StartGameScene.unity";
        EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo();
        EditorSceneManager.OpenScene(localPath);
    }
}
