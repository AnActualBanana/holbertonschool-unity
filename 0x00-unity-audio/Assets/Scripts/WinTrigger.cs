using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinTrigger : MonoBehaviour
{
    public Text timer;
	public GameObject player;
	public GameObject winCanvas;
	void Start()
	{
	}

	void OnTriggerEnter()
	{
		timer.color = Color.green;
		timer.fontSize = 69;
        player.GetComponent<Timer>().Win();
		winCanvas.SetActive(true);
		//Destroy(player.GetComponent<Timer>());
	}
}
