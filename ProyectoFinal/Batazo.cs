using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Batazo : MonoBehaviour
{
    public int damage = 10;
    public float pushForce = 1.2f;
    public int maxHits = 1; // Máximo de veces que puedes golpear al enemigo
    private Dictionary<GameObject, int> hitEnemies = new Dictionary<GameObject, int>();

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Zombie"))
        {
            Debug.Log("Tocado");
            if (!hitEnemies.ContainsKey(other.gameObject))
            {
                hitEnemies.Add(other.gameObject, 1);
            }
            else
            {
                hitEnemies[other.gameObject]++;
            }

            if (hitEnemies[other.gameObject] <= maxHits)
            {
                ZombieIA zombie = other.gameObject.GetComponent<ZombieIA>();
                if (zombie != null)
                {
                    zombie.TakeDamage(damage);

                    Rigidbody enemyRigidbody = other.attachedRigidbody;
                    if (enemyRigidbody != null)
                    {
                        Vector3 forceDirection = other.transform.position - transform.position;
                        forceDirection.y = 0; // Opcional: neutralizar la componente vertical
                        forceDirection.Normalize();
                        enemyRigidbody.AddForce(forceDirection * pushForce, ForceMode.Impulse);
                        Debug.Log("Empuje!");
                    }
                }
            }
        }
    }

    public void StartAttack()
    {
        hitEnemies.Clear();
    }

    // Opcional: Llamado al final de la animación de ataque
    public void EndAttack()
    {
        hitEnemies.Clear();
    }
}
