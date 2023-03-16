using UnityEngine;
using UnityEngine.SceneManagement;

public class OptionsMenu : MonoBehaviour
{
    private string previousScene;


    public void Back()
    {
    // Find the GameObject with the name "sceneManager"
    GameObject manager = GameObject.Find("sceneManager");

    if (manager != null) 
    {
        // The GameObject was found, so we can now access its components or transform
        previousScene = manager.GetComponent<Scenes>().grabscene();
        SceneManager.LoadScene(previousScene);
    }
    else 
    {
        // The GameObject was not found
        Debug.LogError("Could not find GameObject with name 'sceneManager'");
    }
    }

    public void SaveOptions()
    {
        // Save options settings
    }
}
