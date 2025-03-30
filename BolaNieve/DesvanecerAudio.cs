using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesvanecerAudio : MonoBehaviour
{
    public AudioSource audioSource;
    public float duracionFade = 4.0f; // Duración en segundos para el fade

    private bool fading = false;
    private float volumenInicial;

    void Start()
    {
        // Guardar el volumen inicial del AudioSource
        volumenInicial = audioSource.volume;
    }

    void Update()
    {
        // Comprobar si se ha pulsado la tecla "Tab" y comenzar a desvanecer el audio
        if (Input.GetKeyDown(KeyCode.Tab) && !fading)
        {
            fading = true;
            StartCoroutine(FadeOut());
        }
    }

    IEnumerator FadeOut()
    {
        float tiempoInicio = Time.time;
        while (Time.time < tiempoInicio + duracionFade)
        {
            // Calcular el volumen actual basado en el tiempo transcurrido
            float t = (Time.time - tiempoInicio) / duracionFade;
            float nuevoVolumen = Mathf.Lerp(volumenInicial, 0f, t);
            audioSource.volume = nuevoVolumen;
            yield return null;
        }

        // Asegurarse de que el volumen sea exactamente cero al final del desvanecimiento
        audioSource.volume = 0f;
        fading = false;
    }
}
