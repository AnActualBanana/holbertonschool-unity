using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckSphereAudio : MonoBehaviour
{

    private AudioSource footsteps_Grass;
    private AudioSource footsteps_Rock;
    public AudioClip footsteps_Grass_Audio;
    public AudioClip footsteps_Rock_Audio;

    // Start is called before the first frame update
    void Start()
    {
        //grabs audio sources for sound
        footsteps_Grass = GameObject.Find("footsteps_running_grass").GetComponent<AudioSource>();
        footsteps_Rock = GameObject.Find("footsteps_running_rock").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Grass"))
        {
            Debug.Log("sound check");
            footsteps_Grass.Play();
        }
    }
}
