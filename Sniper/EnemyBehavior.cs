using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    public float minSpawnTime = 1f; // Tiempo mínimo entre apariciones
    public float maxSpawnTime = 5f; // Tiempo máximo entre apariciones
    public float activeTime = 2f; // Tiempo que el enemigo estará visible

    private Coroutine spawnCoroutine;

    void OnEnable()
    {
        spawnCoroutine = StartCoroutine(SpawnCycle()); // Iniciar el ciclo de aparición cuando el enemigo es activado
    }

    void OnDisable()
    {
        if (spawnCoroutine != null)
        {
            StopCoroutine(spawnCoroutine); // Detener la coroutine cuando el enemigo es desactivado
        }
    }

    IEnumerator SpawnCycle()
    {
        while (true)
        {
            gameObject.SetActive(false); // Desactivar el enemigo inicialmente
            float spawnTime = Random.Range(minSpawnTime, maxSpawnTime); // Tiempo aleatorio para la próxima aparición
            yield return new WaitForSeconds(spawnTime); // Esperar ese tiempo

            gameObject.SetActive(true); // Activar el enemigo
            yield return new WaitForSeconds(activeTime); // Esperar el tiempo que el enemigo estará activo
        }
    }
}

