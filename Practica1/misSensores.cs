using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class misSensores : MonoBehaviour
{
    public detectorTag delante, detras;
    public bool chocaDelante, chocaDetras;

    public void GetSensors(){
        chocaDelante=delante.choca;
        chocaDetras=detras.choca;
    }
}
