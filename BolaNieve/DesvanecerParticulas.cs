using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class DesvanecerParticulas : MonoBehaviour
{
    public new ParticleSystem particleSystem;
    public float duracionFade = 3.0f; // Duración en segundos para el fade

    private bool fading = false;
    private float intensidadInicial;

    void Start()
    {
        // Guardar la intensidad inicial del sistema de partículas
        intensidadInicial = particleSystem.emission.rateOverTimeMultiplier;
    }

    void Update()
    {
        // Comprobar si se ha pulsado la tecla "Tab" y comenzar a desvanecer las partículas
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
            // Calcular la intensidad actual basada en el tiempo transcurrido
            float t = (Time.time - tiempoInicio) / duracionFade;
            float nuevaIntensidad = Mathf.Lerp(intensidadInicial, 0f, t);
            var em = particleSystem.emission;
            em.rateOverTimeMultiplier = nuevaIntensidad;
            yield return null;
        }

        // Asegurarse de que la intensidad sea exactamente cero al final del desvanecimiento
        var emission = particleSystem.emission;
        emission.rateOverTimeMultiplier = 0f;
        fading = false;
    }
}
