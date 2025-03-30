using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moverV0 : MonoBehaviour
{
    public inputPrimeraPersona miInput;
    public float v, vg;
    Vector3 pos;

    // Update is called once per frame
    void Update()
    {
        // Cojo input
        miInput.GetInput();

        // Giro
        transform.Rotate(miInput.hor*vg*Time.deltaTime*Vector3.up,Space.World);

        // Donde quiero moverme
        pos=transform.position+transform.forward*v*miInput.ver*Time.deltaTime;

        //Me muevo
        transform.position=pos;
    }
}
