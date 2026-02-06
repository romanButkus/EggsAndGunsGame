using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public void Play()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Arena");
    }

    public void CloseApp()
    {
        Application.Quit();
    }
}
