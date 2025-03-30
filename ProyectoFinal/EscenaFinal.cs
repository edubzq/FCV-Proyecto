using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EscenaFinal : MonoBehaviour
{
    public void activarColliderCasaTom()
    {
        GetComponent<Collider>().enabled = true;
    }
    private void OnTriggerEnter(Collider other)
    {
         
        if (other.gameObject.CompareTag("Player"))
        {

            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
