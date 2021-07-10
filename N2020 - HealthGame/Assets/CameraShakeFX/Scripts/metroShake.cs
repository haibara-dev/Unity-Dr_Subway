using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class metroShake : MonoBehaviour
{
    public StressReceiver scrStress;
    public float IntensidadeStress;

    public float TempoStress;
    private float c_time = 0;


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            scrStress.InduceStress(IntensidadeStress);
        }
        TimeSt();
    }


    public void TimeSt()
    {
        if (c_time < TempoStress)
        {
            c_time += Time.deltaTime;
        }
        else
        {
            c_time = 0;
            scrStress.InduceStress(IntensidadeStress);
        }
    }
}
