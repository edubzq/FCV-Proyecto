using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuESC : MonoBehaviour
{
    public GameObject PausePanel, Notas, MP3;
    private bool isNotas = false;
    //private bool isMp3 = false;
    
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)){

            if (isNotas){
                Notas.SetActive(false);
                isNotas = false;
            }
            Pause();
        }
       /* if(Input.GetKeyDown(KeyCode.I)){

            if(isMp3){
                MP3.SetActive(false);
                isMp3 = false;
            }
            musicaON();
        }*/
    }

    public void Pause(){
        PausePanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Continue(){
        PausePanel.SetActive(false);
        Time.timeScale = 1f;
    }

    public void Controles(){
        Notas.SetActive(true);
        isNotas = true;
    }

   /* public void musicaON(){
        MP3.SetActive(true);
        isMp3 = true;
    }
    public void musicaOFF(){

    }*/


}
