using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class controlJuego : MonoBehaviour
{
    public GameObject textos, boton, final, efectos;
    public Animator camAnim;
    public giraCamara miCamara;
    public void empieza(){
        textos.SetActive(false);
        boton.SetActive(false);
        camAnim.SetTrigger("Start");
    }

    public void activaCamara(){
        camAnim.enabled = false;
        miCamara.enabled=true;
    }



}
