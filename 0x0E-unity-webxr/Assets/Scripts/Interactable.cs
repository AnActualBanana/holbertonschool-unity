using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
public class Interactable : MonoBehaviour
{
    public void OnInteraction()
    {
        Debug.Log("Interacted with: " + gameObject.name);
    }
}