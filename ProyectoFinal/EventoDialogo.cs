using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventoDialogo : MonoBehaviour
{
   public DialogueTrigger trigger;
   public GameObject jugador, camara;
   public UnityEvent startDialogue, endDialogue;
   private Collider mycollider;
   private bool dialogando = false;
   private GameObject[] enemies;
   
   void Start()
    {
        // Asegúrate de obtener la referencia al Collider
        mycollider = GetComponent<Collider>();
        enemies = GameObject.FindGameObjectsWithTag("Zombie");
    }

    void Update(){
      
      if(dialogando && !DialogueManager.instance.inDialogue)
      {
         volverAJugador();
         DestruirTrigger();
      }
      enemies = GameObject.FindGameObjectsWithTag("Zombie");
    }

   public void OnTriggerEnter(Collider other){
      if(other.CompareTag("Player"))
      {
         startDialogue.Invoke();
         //Time.timeScale = 0;
         dialogando = true;
         PauseZombieEnemies();
      }
   }
   
   public void cambiaCam(){
      camara.SetActive(true);
      jugador.SetActive(false);
   }
   public void volverAJugador(){
      camara.SetActive(false);
      jugador.SetActive(true);
      //Time.timeScale = 1;
      ResumeZombieEnemies();
   }

   public void DestruirTrigger(){
      Destroy(this.gameObject);
   }

    public void PauseZombieEnemies()
    {
        foreach (GameObject enemy in enemies)
        {
            ZombieIA enemyScript = enemy.GetComponent<ZombieIA>();
            if (enemyScript != null)
            {
                enemyScript.Pause();
            }
        }
    }
    public void ResumeZombieEnemies()
    {
        foreach (GameObject enemy in enemies)
        {
            ZombieIA enemyScript = enemy.GetComponent<ZombieIA>();
            if (enemyScript != null)
            {
                enemyScript.Resume();
            }
        }
    }
}
