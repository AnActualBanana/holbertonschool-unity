using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationTriggers : MonoBehaviour
{
    public GameObject player;
    Animator animator;
    //public CharacterController controller;
    // Start is called before the first frame update
    void Start()
    {
        animator = GameObject.Find("ty").GetComponent<Animator>(); //grabs animator component for access to its parameters(bools, in this case)
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void splatAndGettingUp()
    {
        player.GetComponent<CharacterController>().enabled = false;
    }
    public void gettingUpToIdle()
    {
        player.GetComponent<CharacterController>().enabled = true;
    }
}
