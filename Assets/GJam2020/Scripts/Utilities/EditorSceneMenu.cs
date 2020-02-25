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
        [MenuItem("Scenes/Level1")]
        static void OpenLevel1Scene()
        {
            if (!EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo()) return;
            EditorSceneManager.OpenScene("Assets/GJam2020/Scenes/Level1.unity");
        }
#endif
    }
}