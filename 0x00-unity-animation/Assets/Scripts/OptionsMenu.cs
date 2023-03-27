using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{
    private string previousScene;

    public string invertY;
    public string invertYToggleState;
    public Toggle invertYToggleButton;

    private void start()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
        invertYToggleState = PlayerPrefs.GetString("invertYButtonState");
        invertY = PlayerPrefs.GetString("invertY");
        /* if (invertYToggleState == "true")
        {

        } */
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode) //triggers on loading a new scene
    {
        if (invertYToggleState == "true")
        {
            invertYToggleButton.isOn = true;
        }
    }
    public void Back() //goes back to the previous scene
    {
    // Find the GameObject with the name "sceneManager"
    GameObject manager = GameObject.Find("sceneManager");

        if (manager != null) 
        {
            // The GameObject was found, so we can now access its components or transform
            previousScene = manager.GetComponent<gameManager>().grabscene();
            SceneManager.LoadScene(previousScene);
        }
        else 
        {
            // The GameObject was not found
            Debug.LogError("Could not find GameObject with name 'sceneManager'");
        }
    }

    public void invertYToggle() //changes the invert Y based on toggle
    {
        if (invertY == "false")
            invertY = "true";
        else
            invertY = "false";
    }
    public void SaveOptions() //applies changes to PlayerPrefs
    {
        
        if (invertY == "false")
        {
            PlayerPrefs.SetString("invertY", "false");
            PlayerPrefs.SetString("invertYButtonState", "false");
        }
        else
        {
            PlayerPrefs.SetString("invertY", "true");
            PlayerPrefs.SetString("invertYButtonState", "true");
        }
        // Save options settings
    }
}
