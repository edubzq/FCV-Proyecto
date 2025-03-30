using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetenerBola : MonoBehaviour
{
    public Rigidbody bola;
    public float umbralVelocidad = 2.0f;
    [SerializeField] private giraCamara giracam;
    // Update is called once per frame
    void Update()
    {
        if (bola.velocity.magnitude < umbralVelocidad)
        {
            Detener();
        }
    }
    void Detener()
    {
        giracam.moviendo = false;
        bola.velocity = Vector3.zero;
        bola.angularVelocity = Vector3.zero;
    }
       
}
