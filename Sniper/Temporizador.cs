using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Temporizador : MonoBehaviour
{
    public Text textoTemporizador;
    private float tiempoRestante = 60f;
    private bool temporizadorCorriendo = true;

    // Update is called once per frame
    void Update()
    {
        if (temporizadorCorriendo)
        {
            tiempoRestante -= Time.deltaTime;
            ActualizarTextoTemporizador();
            if (tiempoRestante <= 0)
            {
                tiempoRestante = 0;
                temporizadorCorriendo = false;
                
            }
        }

    void ActualizarTextoTemporizador()
    {
        int segundos = Mathf.FloorToInt(tiempoRestante % 60);
        textoTemporizador.text = segundos.ToString("00");
    }
    }
}
