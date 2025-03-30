using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inputPrimeraPersona : MonoBehaviour
{
    public string Horizontal, Vertical;
    public KeyCode salto;

    public float hor, ver;
    public bool saltar;
    // Start is called before the first frame update
    public void GetInput(){
        hor=Input.GetAxis(Horizontal);
        ver=Input.GetAxis(Vertical);
        saltar=Input.GetKey(salto);

    }
}
