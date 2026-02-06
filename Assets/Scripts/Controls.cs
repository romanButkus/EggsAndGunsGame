using UnityEngine;
using UnityEngine.SceneManagement;

public class Controls : MonoBehaviour
{
    [SerializeField] private GameObject _pausepanel;
    [SerializeField] private GameObject _pauseButton;

    void Update()
    {
        Pause();
    }

    public void Pause()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Time.timeScale == 1)
            {
                _pausepanel.SetActive(true);
                _pauseButton.SetActive(false);
                Time.timeScale = 0;
            }

            else if (Time.timeScale == 0)
            {
                _pausepanel.SetActive(false);
                _pauseButton.SetActive(true);
                Time.timeScale = 1;
            }
        }
    }

    public void Continue()
    {
        Time.timeScale = 1;
    }

    public void PauseButton()
    {
        Time.timeScale = 0;
    }
    
    public void ExitToMainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
    }
}
