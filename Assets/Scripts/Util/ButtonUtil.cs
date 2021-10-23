using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonUtil : MonoBehaviour
{
    public void MoveScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
    }

    public void PlayButtonSfx()
    {
        SoundManager.Instance.PlaySfx("Click");
    }
}
