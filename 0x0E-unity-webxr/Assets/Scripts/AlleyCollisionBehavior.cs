using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace WebXR.Interactions
{
public class AlleyCollisionBehavior : MonoBehaviour
{
    public GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Interactable")
        {
            if (other.gameObject.GetComponent<BowlingBallBehavior>().currentState == BowlingBallBehavior.BallState.Thrown)
                {
                    gameManager.AlleyCollisionEnter(other.gameObject);
                }
        }
    }
}
}
