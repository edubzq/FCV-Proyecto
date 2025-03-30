using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mover4 : MonoBehaviour
{
    public inputPrimeraPersona miInput;
    public misSensores sensores;
    public float v, vg, g, vyMax;


    public LayerMask suelo;
    Vector3 pos;
    RaycastHit hit;
    float vy;
    bool toco;

    void Start(){
        vy=0;
    }
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

        toco=Physics.Raycast(transform.position,Vector3.down,out hit,1.0f,suelo);
        if(toco){
            if(vy>=0){
                pos=new Vector3(pos.x,hit.point.y+1,pos.z);
                vy=0;
            }
        }
        else{
            vy+=g*Time.deltaTime;
            if(vy>vyMax){vy=vyMax;}
        }

        
        pos+=vy*Time.deltaTime*Vector3.down;

        
        pos+=vy*Time.deltaTime*Vector3.down;
        //Me muevo
        transform.position=pos;
    }
}
