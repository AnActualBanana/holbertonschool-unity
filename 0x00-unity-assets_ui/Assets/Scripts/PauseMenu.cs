using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseCanvas;
    private bool isPaused = false;
    private float previousTimeScale;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!isPaused)
            {
                Pause();
            }
            else
            {
                Resume();
            }
        }
    }

    public void Pause()
    {
        previousTimeScale = Time.timeScale;
        Time.timeScale = 0;
        isPaused = true;
        pauseCanvas.SetActive(true);
    }

    public void Resume()
    {
        Time.timeScale = previousTimeScale;
        isPaused = false;
        pauseCanvas.SetActive(false);
    }
}
