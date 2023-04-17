using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reset : MonoBehaviour
{

public GameObject player;
public GameObject teleportSpawnPoint;
CharacterController controller;
private void OnTriggerEnter(Collider other) 
{
    controller = player.GetComponent<CharacterController>();

    if (other.gameObject.CompareTag("Player"))
    {
        controller.enabled = false;
        GameObject.Find("ty").GetComponent<Animator>().SetBool("isJumping", false);
        GameObject.Find("ty").GetComponent<Animator>().SetBool("isFalling", false);
        GameObject.Find("ty").GetComponent<Animator>().SetBool("isWalking", false);
        player.transform.position = teleportSpawnPoint.transform.position;
        GameObject.Find("ty").GetComponent<Animator>().SetBool("isSplatting", true);
        controller.enabled = true;
        Debug.Log("Reset");
    }
}
}
