using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class detectorTag : MonoBehaviour
{
    public bool choca;
    public string tag;
    public Material azul, rojo;
    MeshRenderer renderer;
    void Start(){
        renderer=GetComponent<MeshRenderer>();
    }
    // Start is called before the first frame update
    void OnCollisionEnter(Collision colision){
      
        if(colision.gameObject.tag==tag){
            choca=true;
            renderer.material=rojo;
        }
    }

    void OnCollisionExit(){
        choca=false;
        renderer.material=azul;
    }
}
