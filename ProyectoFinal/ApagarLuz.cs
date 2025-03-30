using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apagarluz : MonoBehaviour
{
    public GameObject objeto;

    public void apagaLuz(){
        Light lightComponent = objeto.GetComponent<Light>();
        lightComponent.enabled = false;
    }
}
