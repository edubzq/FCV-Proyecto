using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mover3 : MonoBehaviour
{
    public inputPrimeraPersona miInput;
    public misSensores sensores;
    public float v, vg;
    public LayerMask suelo;
    Vector3 pos;
    RaycastHit hit;

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

        if(Physics.Raycast(transform.position,Vector3.down,out hit,1.0f,suelo)){
            pos=new Vector3(pos.x,hit.point.y+1,pos.z);
        }
        //Me muevo
        transform.position=pos;
    }
}
