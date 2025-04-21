using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public float TimeLeft = 80;
    public bool Timeon = false;

    [SerializeField] TextMeshProUGUI time;
    void Start()
    {
        Timeon = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Timeon)
        {
                TimeLeft += Time.deltaTime;
                updateTime(TimeLeft);
        }
    }
    void updateTime(float curentTime)
    {
        //curentTime += 1;
        //float min = Mathf.FloorToInt(curentTime / 60);
        //float sec = Mathf.FloorToInt(curentTime % 60);
        //time.text = string.Format("{0:0:00} : {0:0:00} : {1:0:00}", hour, min, sec);

        TimeSpan T = TimeSpan.FromSeconds(curentTime);//bi5tisar hhh
        time.text = T.ToString(@"hh\:mm\:ss");
    }
}
