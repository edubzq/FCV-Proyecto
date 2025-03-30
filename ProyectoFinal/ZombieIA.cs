using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

public class ZombieIA : MonoBehaviour
{
    public bool isHostile = false;
    Transform currentWayPoint;
    public NavMeshAgent AiAgent;
    GameObject player;
    public float distanceToPlayerAttack, distanceToPlayerChase, distanceToStopChase;
    public float speed = 2f;
    public float attackSpeed = 0.5f;
    public int zombieHP = 150;
    private float distanceToPlayer;

    public Transform moveAreaCenter; // Centro del área de movimiento del zombie
    public float moveAreaRadius = 10f; // Radio del área de movimiento del zombie

    private float timeSinceDestinationSet; // Tiempo transcurrido desde que se estableció el destino actual
    private float recalculateDestinationTime = 9f; // Tiempo después del cual se recalcula el destino

    public UnityEvent onPlayerInRange, onPlayerDetected, onPlayerLost; //Sin uso


    void Start()
    {
        player = GameObject.FindWithTag("Player");
        currentWayPoint = new GameObject("Waypoint").transform;
        GenerateRandomDestination();
    }

    void Update()
    {
        distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);
        if(distanceToPlayer > distanceToStopChase)
        {
            isHostile = false;
        }
        if (!isHostile)
        {
            AiAgent.SetDestination(currentWayPoint.position);
            AiAgent.speed = speed;
            if (Time.time - timeSinceDestinationSet > recalculateDestinationTime || (!AiAgent.pathPending && AiAgent.remainingDistance < 0.1f))
            {
                GenerateRandomDestination();
            }
        }
        
        if (distanceToPlayer < distanceToPlayerChase)
        {
            onPlayerDetected.Invoke(); //Llamar a sonido?
            Chase();
        }

        if (distanceToPlayer < distanceToPlayerAttack)
        {
            onPlayerInRange.Invoke();
        }
        
                
    }

    public void Chase(){
        isHostile = true;
        AiAgent.speed = speed;
        AiAgent.SetDestination(player.transform.position);
    }

   public void TakeDamage(int amount)
    {
        zombieHP -= amount;
        SoundManager.PlaySound(SoundType.ZDAMAGE);
        Debug.Log(zombieHP);
        if (zombieHP <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        
        Debug.Log("Enemigo derrotado!");
        Destroy(gameObject);
    }


    void GenerateRandomDestination()
    {
        // Generar un punto aleatorio dentro del área de movimiento del zombie
        Vector3 randomDestination = moveAreaCenter.position + Random.insideUnitSphere * moveAreaRadius;
        randomDestination.y = transform.position.y; // Asegurar que la Y sea la misma que la del zombie
        currentWayPoint.position = randomDestination;
        timeSinceDestinationSet = Time.time; // Actualizar el tiempo del último destino establecido
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, distanceToPlayerAttack);
        Gizmos.DrawWireSphere(transform.position, distanceToPlayerChase);

        // Dibujar el área de movimiento
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(moveAreaCenter.position, moveAreaRadius);
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, distanceToStopChase);
    }

    private bool isPaused = false;

    public void Pause()
    {
        if (!isPaused)
        {
            speed = 0;
            isPaused = true;
        }
    }
    public void Resume()
    {
        if (isPaused)
        {
            speed = 2;
            isPaused = false;
        }
    }
}

