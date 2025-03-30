using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cogeObjetos : MonoBehaviour
{
    // Start is called before the first frame update
    public string tag;

    void OnCollisionEnter(Collision colision){
        if(colision.gameObject.tag==tag){
            Destroy(colision.gameObject);
        }
    }
}
