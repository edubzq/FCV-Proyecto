using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class detector : MonoBehaviour
{
    public bool choca;
    public Material azul, rojo;
    MeshRenderer renderer;
    void Start(){
        renderer=GetComponent<MeshRenderer>();
    }
    // Start is called before the first frame update
    void OnCollisionEnter(Collision colision){
        choca=true;
        renderer.material=rojo;
    }

    void OnCollisionExit(){
        choca=false;
        renderer.material=azul;
    }
}
