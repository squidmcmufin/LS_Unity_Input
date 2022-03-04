using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scr_Timer : MonoBehaviour
{
    public float time = 0f;
    public bool timer_is_running = false;
    public Text timetext;

    // Start is called before the first frame update
    void Start()
    {
        timer_is_running = true;
    }
    
    // Update is called once per frame
    void Update()
    {
        if (timer_is_running)
        {
            time += Time.deltaTime;
            DisplayTime(time);
        }


    }

    void DisplayTime(float timetoodisplay)
    {
        timetoodisplay += 1;
        float minutes = Mathf.FloorToInt(timetoodisplay / 60);
        float seconds = Mathf.FloorToInt(timetoodisplay % 60);
        timetext.text = minutes.ToString()+":"+ seconds.ToString();
    }
}
