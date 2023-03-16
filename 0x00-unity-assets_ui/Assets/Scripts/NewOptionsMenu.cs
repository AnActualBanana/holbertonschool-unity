using UnityEngine;
using UnityEngine.SceneManagement;

public class NewOptionsMenu : MonoBehaviour
{
    private string previousScene;

    void Start()
    {
        previousScene = SceneManager.GetActiveScene().name;
    }

    void Awake()
    {
        // Make this object persistent between scene loads
        DontDestroyOnLoad(this.gameObject);
    }
    public void Back()
    {
        SceneManager.LoadScene(previousScene);
    }

    public void SaveOptions()
    {
        // Save options settings
    }
}
