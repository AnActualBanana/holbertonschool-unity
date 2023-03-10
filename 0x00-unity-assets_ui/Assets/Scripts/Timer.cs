using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text TimerText;
    private float time;
    private float minutes;
    private float seconds;
    private float milliseconds;
    // Start is called before the first frame update
    void Start()
    {
        time = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        minutes = Mathf.FloorToInt(time/60f);
        seconds = Mathf.FloorToInt(time%60f);
        milliseconds = time*1000%1000f;

        TimerText.text = minutes.ToString() + ":" + seconds.ToString() + "." + milliseconds.ToString("0");
    }
}
