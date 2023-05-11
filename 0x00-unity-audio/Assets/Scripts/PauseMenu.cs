using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
public class PauseMenu : MonoBehaviour
{
    public GameObject pauseCanvas;
    public AudioMixerSnapshot pause;
    public AudioMixerSnapshot play;
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
        pause.TransitionTo(.1f);
    }

    public void Resume()
    {
        Time.timeScale = previousTimeScale;
        isPaused = false;
        pauseCanvas.SetActive(false);
        play.TransitionTo(.1f);
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1;
        play.TransitionTo(.1f);
    }

    public void Options()
    {
        SceneManager.LoadScene("Options");
        Time.timeScale = 1;
    }
}
