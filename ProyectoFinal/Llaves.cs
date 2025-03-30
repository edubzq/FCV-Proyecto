using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Llaves : MonoBehaviour
{
 
    public GameObject collider, anuncio, llaves;
  

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            
            anuncio.SetActive(true);
            llaves.SetActive(true);
          
        }
    }

    private void OnTriggerExit(Collider other)
    {
        collider.SetActive(true);
        anuncio.SetActive(false);
    }
    
}
