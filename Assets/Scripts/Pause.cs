using UnityEngine;

public class Controlds : MonoBehaviour
{
    [SerializeField] private GameObject _pausepanel;

	void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Time.timeScale == 1)
            {
                _pausepanel.SetActive(true);
                Time.timeScale = 0;
            }

            else if (Time.timeScale == 0)
            {
                _pausepanel.SetActive(false);
                Time.timeScale = 1;
            }
        }
    }

}
