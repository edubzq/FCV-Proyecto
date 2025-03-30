using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EncenderApagarAleatorio : MonoBehaviour
{
    public Light[] luces;
    public float intervaloMinimo = 1f;
    public float intervaloMaximo = 3f;

    void Start()
    {
        // Iniciar el temporizador aleatorio para cada luz
        foreach (Light luz in luces)
        {
            StartCoroutine(AlternarLuz(luz));
        }
    }

    IEnumerator AlternarLuz(Light luz)
    {
        while (true)
        {
            // Esperar un tiempo aleatorio antes de cambiar el estado de la luz
            yield return new WaitForSeconds(Random.Range(intervaloMinimo, intervaloMaximo));

            // Cambiar el estado de la luz
            luz.enabled = !luz.enabled;
        }
    }
}