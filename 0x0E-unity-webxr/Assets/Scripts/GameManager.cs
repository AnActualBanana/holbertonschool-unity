using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace WebXR.Interactions
{
public class GameManager : MonoBehaviour
{
    public GameObject currentBall;
    public GameObject player;
    public GameObject handL;
    public GameObject handR;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("WebXRCameraSet");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void AlleyCollisionEnter(GameObject ball)
    {
        handL.GetComponent<ControllerInteractionNew>().enabled = false;
        handR.GetComponent<ControllerInteractionNew>().enabled = false;
        player.GetComponent<KeyboardController>().enabled = false;
        //enable ball spin controller
        //change camera to spectator view
    }
    public void BallFinished()
    {
        handL.GetComponent<ControllerInteractionNew>().enabled = true;
        handR.GetComponent<ControllerInteractionNew>().enabled = true;
        player.GetComponent<KeyboardController>().enabled = true;
        //disable ball spin controller
        //change camera back to normal
    }
}
}
