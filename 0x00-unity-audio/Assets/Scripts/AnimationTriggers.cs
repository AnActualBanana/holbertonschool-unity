using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationTriggers : MonoBehaviour
{
    public GameObject player;
    Animator animator;
    private AudioSource footsteps_Grass;
    private AudioSource footsteps_Rock;
    
    private AudioSource landing_Grass;
    private AudioSource landing_Rock;
    //public CharacterController controller;
    RaycastHit hit;
    // Start is called before the first frame update
    void Start()
    {
        animator = GameObject.Find("ty").GetComponent<Animator>(); //grabs animator component for access to its parameters
        //grabs audio sources for sound
        footsteps_Grass = GameObject.Find("footsteps_running_grass").GetComponent<AudioSource>();
        footsteps_Rock = GameObject.Find("footsteps_running_rock").GetComponent<AudioSource>();
        landing_Grass = GameObject.Find("footsteps_landing_grass").GetComponent<AudioSource>();
        landing_Rock = GameObject.Find("footsteps_landing_rock").GetComponent<AudioSource>();
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
    public void playWalkingSFX()
    {
        //audio for walking
                if (Physics.Raycast(transform.position, -(transform.up), out hit))
                    {

                    if (hit.collider.gameObject.CompareTag("Grass"))
                        {
                                footsteps_Grass.Play();
                        }
                    else if (hit.collider.gameObject.CompareTag("Rock"))
                        {
                                footsteps_Rock.Play();
                        }
                    
                    }     
    }
        public void playLandingSFX()
        {
            //audio for walking
                if (Physics.Raycast(transform.position, -(transform.up), out hit))
                    {

                    if (hit.collider.gameObject.CompareTag("Grass"))
                        {
                                landing_Grass.Play();
                        }
                    else if (hit.collider.gameObject.CompareTag("Rock"))
                        {
                                landing_Rock.Play();
                        }
                    
                    }     
        }
}
