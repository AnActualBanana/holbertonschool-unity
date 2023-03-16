using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameManager : MonoBehaviour
{
    public GameObject _gameManager = null;
    public string previousScene;
    public string currentScene;
    private void Awake() {
        {

            DontDestroyOnLoad(this.gameObject);
        }
    }
    void Start()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
        currentScene = SceneManager.GetActiveScene().name;
    }
    void OnSceneLoaded(Scene scene, LoadSceneMode mode) //triggers on loading a new scene
    {
        //moves previous scene and current scene names
        previousScene = currentScene;
        currentScene = SceneManager.GetActiveScene().name;
        Debug.Log("OnSceneLoaded: " + scene.name);
        Debug.Log(mode);
    }
    public string grabscene() //returns current scene name
    
    {

        return previousScene;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
