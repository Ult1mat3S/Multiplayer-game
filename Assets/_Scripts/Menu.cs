#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
public string menuName;
public bool open;

    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

public void Open() {
    open = true;
    gameObject.SetActive(true);

}

public void Close() {
    open = false;
    gameObject.SetActive(false);
}

    public void QuitGame()
    {
        Application.Quit();
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#endif
    }
}
