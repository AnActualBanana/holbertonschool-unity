using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class orbsCounter : MonoBehaviour
{
    GameObject player;
    public Text OrbText;
    // Start is called before the first frame update
    void Start()
    {
        player = this.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        OrbText.text = "Orbs Remaining: " + (20 - player.GetComponent<PlayerController>().orbs);
    }
}
