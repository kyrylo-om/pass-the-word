using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class ClockRefresh : MonoBehaviour
{
    public Text timeText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        string hour = "";
        string minute = "";
        if (System.DateTime.Now.Hour > 9)
        {
            hour = System.DateTime.Now.Hour.ToString();
        }
        if (System.DateTime.Now.Hour <= 9)
        {
            hour = "0" + System.DateTime.Now.Hour.ToString();
        }
        if (System.DateTime.Now.Minute > 9)
        {
            minute = System.DateTime.Now.Minute.ToString();
        }
        if (System.DateTime.Now.Minute <= 9)
        {
            minute = "0" + System.DateTime.Now.Minute.ToString();
        }
        timeText.text = hour + ":" + minute;
    }
}
