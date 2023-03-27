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
    controller = GetComponent<CharacterController>();

    if (other.gameObject.CompareTag("Reset"))
    {
        controller.enabled = false;
        player.transform.position = teleportSpawnPoint.transform.position;
        controller.enabled = true;
        Debug.Log("Reset");
    }
}
}
