using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float Maxtime = 30f;
    public float TimeLeft;
    public Data data;

    public bool active = false;

    public void Start()
    {
        Maxtime = data.MaxBatteryTime;
    }

    public void Reset()
    {
        Maxtime = data.MaxBatteryTime;
        TimeLeft = Maxtime;
    }

    public void StartTimer()
    {
        active = true;
    }

    public void StopTimer()
    {
        active = false;
    }

    void Update()
    {
        if (active)
        {
            TimeLeft -= Time.deltaTime;
            if (TimeLeft <= 0)
            {
                TimeLeft = 0;
                active = false;
            }
        }
    }
}
