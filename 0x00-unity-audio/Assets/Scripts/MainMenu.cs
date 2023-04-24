using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
public class MainMenu : MonoBehaviour
{

    private void awake()
    {
        Debug.Log("On awake, playerprefs = " + PlayerPrefs.GetString("invertY"));
    }

    public void LevelSelect(int level) //loads appropriate level (button)
    {
        SceneManager.LoadScene("Level0" + level);
    }

    public void Options() //opens options menu (button)
    {
        SceneManager.LoadScene("Options");
    }

    public void Exit() //quits game (button)
    {
        Debug.Log("Exited");
        Application.Quit();
    }
}
