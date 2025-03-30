using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mover2 : MonoBehaviour
{
    public inputPrimeraPersona miInput;
    public misSensores sensores;
    public float v, vg;
    Vector3 pos;

    // Update is called once per frame
    void Update()
    {
        // Cojo input
        miInput.GetInput();
        sensores.GetSensors();

        // Giro
        transform.Rotate(miInput.hor*vg*Time.deltaTime*Vector3.up,Space.World);

        // Donde quiero moverme
        pos=transform.position+transform.forward*v*miInput.ver*Time.deltaTime;

        if(miInput.ver>0 && sensores.chocaDelante || miInput.ver<0 && sensores.chocaDetras){
            pos=transform.position;
        }
        //Me muevo
        transform.position=pos;
    }
}
