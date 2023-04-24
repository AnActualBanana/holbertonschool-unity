using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
public class OptionsMenu : MonoBehaviour
{
    private string previousScene;

    public string invertY;
    public string invertYToggleState;
    public Toggle invertYToggleButton;
    public AudioMixerGroup Running;
    public AudioMixerGroup Landing;
    public AudioMixerGroup Ambience;
    public AudioMixerGroup MenuSFX;
    public AudioMixerGroup BGM;
    public Slider SFXSlider;
    private float SFXdb;
    public Slider BGMSlider;
    private float BGMdb;

    private void start()
    {
        invertYToggleState = PlayerPrefs.GetString("invertYButtonState");
        invertY = PlayerPrefs.GetString("invertY");
    }
    private void Awake()
    {
        SFXSlider.value = PlayerPrefs.GetFloat("SFXVolume");
        BGMSlider.value = PlayerPrefs.GetFloat("BGMVolume");
        //Debug.Log(SFXdb);
        invertYToggleState = PlayerPrefs.GetString("invertYButtonState");
        invertY = PlayerPrefs.GetString("invertY");
        if (invertYToggleState == "true")
        {
            if (invertYToggleButton.isOn == false)
            {
                invertYToggleButton.isOn = true;
                invertY = "true";
            }
        }
        else
        {
            if (invertYToggleButton.isOn == true)
            {
                invertYToggleButton.isOn = false;
                invertY = "false";
            }
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
        //converts audio slider values to decibels
        //BGM
        if (BGMSlider.value != 0)
            BGMdb = 20.0f * Mathf.Log10(BGMSlider.value);
        else
            BGMdb = -144.0f;
        //SFX
        if (SFXSlider.value != 0)
            SFXdb = 20.0f * Mathf.Log10(SFXSlider.value);
        else
            SFXdb = -144.0f;
        //saves invertY setting
        if (invertY == "false")
        {
            PlayerPrefs.SetString("invertY", "false");
            PlayerPrefs.SetString("invertYButtonState", "false");
        }
        else if (invertY == "true")
        {
            PlayerPrefs.SetString("invertY", "true");
            PlayerPrefs.SetString("invertYButtonState", "true");
        }
        //saves sound slider settings to playerprefs
        Running.audioMixer.SetFloat("RunningVolume", SFXdb);
        Landing.audioMixer.SetFloat("LandingVolume", SFXdb);
        Ambience.audioMixer.SetFloat("AmbienceVolume", SFXdb);
        MenuSFX.audioMixer.SetFloat("MenuSFXVolume", SFXdb);
        BGM.audioMixer.SetFloat("BGMVolume", BGMdb);
        PlayerPrefs.SetFloat("SFXVolume", SFXSlider.value);
        PlayerPrefs.SetFloat("BGMVolume", BGMSlider.value);
         // Save options settings
        PlayerPrefs.Save();
    }
}
