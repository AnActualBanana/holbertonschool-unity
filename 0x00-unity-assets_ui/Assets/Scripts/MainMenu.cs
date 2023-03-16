using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private void awake()
    {
        Debug.Log("On awake, playerprefs = " + PlayerPrefs.GetString("invertY"));
    }
    public void LevelSelect(int level) //loads appropriate level
    {
        SceneManager.LoadScene("Level0" + level);
    }

    public void Options() //opens options menu
    {
        SceneManager.LoadScene("Options");
    }

    public void Exit() //quits game
    {
        Debug.Log("Exited");
        Application.Quit();
    }
}
