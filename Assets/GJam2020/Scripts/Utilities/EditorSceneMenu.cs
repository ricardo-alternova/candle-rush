using UnityEditor;
using UnityEditor.SceneManagement;

namespace UnityEditor.SceneManagement
{
    public class EditorSceneMenu
    {
#if UNITY_EDITOR
        [MenuItem("Scenes/MainMenu")]
        static void OpenMainMenuScene()
        {
            if (!EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo()) return;
            EditorSceneManager.OpenScene("Assets/GJam2020/Scenes/MainMenu.unity");
        }
        [MenuItem("Scenes/Gameplay")]
        static void OpenCommonLevelScene()
        {
            if (!EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo()) return;
            EditorSceneManager.OpenScene("Assets/GJam2020/Scenes/Gameplay.unity");
        }
#endif
    }
}