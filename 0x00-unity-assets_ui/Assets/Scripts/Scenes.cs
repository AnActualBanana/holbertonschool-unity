using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scenes : MonoBehaviour
{
    public string previousScene;
    private void Awake() {
        {
            DontDestroyOnLoad(this.gameObject);
        }
    }
    void Start()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
        previousScene = SceneManager.GetActiveScene().name;
    }
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        previousScene = scene.name;
        Debug.Log("OnSceneLoaded: " + scene.name);
        Debug.Log(mode);
    }
    public string grabscene()
    
    {

        return previousScene;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
