using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mover6 : MonoBehaviour
{
    public inputPrimeraPersona miInput;
    public misSensores sensores;
    public float v, vg, g, vyMax, vSalto;


    public LayerMask suelo;
    Vector3 pos;
    RaycastHit hit;
    float vy;
    bool saltando, toco;

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

        toco=Physics.Raycast(transform.position,Vector3.down,out hit,1.05f,suelo);
        if(toco){
            if(hit.collider.gameObject.tag=="movil"){
                transform.parent=hit.transform.parent;
            }
            else{
                transform.parent=null;
            }
            if(miInput.saltar && !saltando){
                vy=-vSalto;
                saltando=true;}
            else{
                if(vy>=0){
                    saltando=false;
                    pos=new Vector3(pos.x,hit.point.y+1,pos.z);
                    vy=0;
                }
            }
        }
        else{
            vy+=g*Time.deltaTime;
            if(vy>vyMax){vy=vyMax;}
            transform.parent=null;
        }

        
        pos+=vy*Time.deltaTime*Vector3.down;
        //Me muevo
        transform.position=pos;
    }
}
