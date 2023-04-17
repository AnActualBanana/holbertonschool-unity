using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CutsceneController : MonoBehaviour
{
    public GameObject player;
    Animator animator;
    public GameObject mainCamera;
    public GameObject timerCanvas;
    int currentLevelNumber = 0;
    private void Awake() 
    {

    }
    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        //assigns levelNumber int on animator to the name of level loaded
        animator = GameObject.Find("CutSceneCamera").GetComponent<Animator>();
        currentLevelNumber = int.Parse(scene.name.Substring(5, 2));
        animator.SetInteger("levelNumber", currentLevelNumber);
        
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void givePlayerControl()
    {
        mainCamera.SetActive(true);
        player.GetComponent<PlayerController>().enabled = true;
        timerCanvas.SetActive(true);
        this.gameObject.SetActive(false);
    }
}
