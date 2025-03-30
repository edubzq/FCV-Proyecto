using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Controlador : MonoBehaviour
{
    public GameObject btnPlay, btnQuit, txtTime, timeValue, txtAmmo,
                        ammoValue, txtScore, scoreValue, gameLogo, scope, farolaRota, antenaRota, txtIntro, gameOverText;
    public GameObject[] farolas, antenas, enemies, ammo;

    public Animator enAnimator;
    public AudioSource shot;

    private List<GameObject> farolasActivas = new List<GameObject>();
    private List<GameObject> antenasActivas = new List<GameObject>();

    private int puntuacion = 0;
    private Text scoreText, ammoText, timeText;
    private int municion = 8;
    private float tiempoIntro = 5f;
    private float tiempoRestante = 60f;
    private bool temporizadorCorriendo = true;
    private bool todosDisparados = false;

    private bool spawnear = false;

    private void Start()
    {
        scoreText = scoreValue.GetComponent<Text>();
        ammoText = ammoValue.GetComponent<Text>();
        timeText = timeValue.GetComponent<Text>();

        if (txtIntro != null)
        {
            StartCoroutine(MostrarTextoTemporal());
        }

        farolasActivas.AddRange(farolas);
        antenasActivas.AddRange(antenas);

        // Desactivar todos los enemigos al inicio
        foreach (GameObject enemy in enemies)
        {
            enemy.SetActive(false);
        }
    }

    public void comenzar()
    {
        Time.timeScale = 1f;
        btnPlay.SetActive(false);
        btnQuit.SetActive(false);
        txtTime.SetActive(true);
        timeValue.SetActive(true);
        txtAmmo.SetActive(true);
        ammoValue.SetActive(true);
        txtScore.SetActive(true);
        scoreValue.SetActive(true);
        gameLogo.SetActive(false);
        enAnimator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            disparar();

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {

                for (int i = 0; i < farolasActivas.Count; i++)
                {
                    if (hit.collider.gameObject == farolasActivas[i])
                    {
                        ReemplazarObjeto(hit.collider.gameObject, farolaRota);
                        farolasActivas.RemoveAt(i);
                        VerificarDisparos();
                        return;
                    }
                }

                for (int i = 0; i < antenasActivas.Count; i++)
                {
                    if (hit.collider.gameObject == antenasActivas[i])
                    {
                        ReemplazarObjeto(hit.collider.gameObject, antenaRota);
                        antenasActivas.RemoveAt(i);
                        VerificarDisparos();
                        return;
                    }
                }

                for (int i = 0; i < enemies.Length; i++)
                {
                    if (hit.collider.gameObject == enemies[i])
                    {
                        ActualizarPuntuacion();
                        DesactivarEnemy(enemies[i]);
                        return;
                    }
                }

                for (int i = 0; i < ammo.Length; i++)
                {
                    if (hit.collider.gameObject == ammo[i])
                    {
                        recargar();
                        Destroy(ammo[i]);
                        return;
                    }
                }
            }
        }

        if (temporizadorCorriendo)
        {
            tiempoRestante -= Time.deltaTime;
            ActualizarTextoTemporizador();

            if (tiempoRestante <= 0)
            {
                finalizarJuego();
            }
        }

        if (municion == 0)
        {
            finalizarJuego();
        }

        if (!todosDisparados)
       {
            VerificarDisparos();
       }

    }

    private void VerificarDisparos()
    {

        if (farolasActivas.Count == 0 && antenasActivas.Count == 0)
        {
            todosDisparados = true;
            StartCoroutine(RandomEnemyActivation());
        }
    }

    private IEnumerator MostrarTextoTemporal()
    {
        txtIntro.gameObject.SetActive(true);
        yield return new WaitForSeconds(tiempoIntro);
        txtIntro.gameObject.SetActive(false);
    }

    private void ActualizarTextoTemporizador()
    {
        int segundos = Mathf.FloorToInt(tiempoRestante % 60);
        timeText.text = segundos.ToString("00");
    }

    private void DesactivarEnemy(GameObject enemy)
    {
        enemy.SetActive(false);
    }

    private void ReemplazarObjeto(GameObject objetoActual, GameObject objetoNuevo)
    {
        GameObject nuevoObjeto = Instantiate(objetoNuevo, objetoActual.transform.position, objetoActual.transform.rotation);
        Destroy(objetoActual);
    }

    private void disparar()
    {
        if (ammoText != null)
        {
            shot.Play();
            municion--;
            ammoText.text = municion.ToString();
        }
    }

    private void recargar()
    {
        if (ammoText != null)
        {
            municion += 8;
            ammoText.text = municion.ToString();
        }
    }

    private void ActualizarPuntuacion()
    {
        if (scoreText != null)
        {
            puntuacion += 1;
            scoreText.text = puntuacion.ToString();
        }
    }

    private void finalizarJuego()
    {
        Time.timeScale = 0f;
        gameOverText.gameObject.SetActive(true);
        btnQuit.SetActive(true);
        txtTime.SetActive(false);
        timeValue.SetActive(false);
        txtAmmo.SetActive(false);
        ammoValue.SetActive(false);
        txtScore.SetActive(false);
        scoreValue.SetActive(false);
        gameLogo.SetActive(true);
    }

    public void quit()
    {
        Application.Quit();
    }

    private void ActivarEnemigos()
    {
        foreach (GameObject enemy in enemies)
        {
            enemy.SetActive(true);
        }
    }

     IEnumerator RandomEnemyActivation()
    {
        while (true)
        {
            // Elegir un índice aleatorio dentro del rango de enemies
            int randomIndex = Random.Range(0, enemies.Length);

            // Activar el enemigo seleccionado
            GameObject enemyToActivate = enemies[randomIndex];
            enemyToActivate.SetActive(true);

            // Esperar 5 segundos
            yield return new WaitForSeconds(5f);

            // Desactivar el enemigo después de 5 segundos
            enemyToActivate.SetActive(false);
        }
    }

    void RemoveEnemy(GameObject enemyToRemove)
    {
        // Convertir el arreglo en una lista temporal
        List<GameObject> tempList = new List<GameObject>(enemies);

        // Buscar y eliminar el enemigo deseado de la lista
        if (tempList.Contains(enemyToRemove))
        {
            tempList.Remove(enemyToRemove);
            Debug.Log("Enemigo eliminado: " + enemyToRemove.name);
        }
        else
        {
            Debug.LogWarning("El enemigo especificado no está en el arreglo.");
        }

        // Actualizar el arreglo con la lista modificada
        enemies = tempList.ToArray();
    }
}







