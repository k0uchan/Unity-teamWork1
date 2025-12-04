using UnityEngine;

public class QuitGame : MonoBehaviour
{
    // 这个方法用来退出游戏
    public void Quit()
    {
        // 如果在编辑器中测试
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        // 构建后的游戏退出
        Application.Quit();
#endif
    }
}