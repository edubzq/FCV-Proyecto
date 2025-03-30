using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    public GameObject controlador;
    // Start is called before the first frame update
    void Start()
    {
           Time.timeScale = 0f;
           if (controlador != null)
        {
            controlador.SetActive(false); // Asegúrate de que el objeto Controlador esté desactivado al inicio
        }
    }

    // Update is called once per frame
    public void entrarJuego()
    {
        if (controlador != null)
        {
            controlador.SetActive(true);
            controlador.GetComponent<Controlador>().comenzar();
        }
    }
}
