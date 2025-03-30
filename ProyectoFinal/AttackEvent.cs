using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackEvent : MonoBehaviour
{
    public Animator anim;
   

    public void OnTriggerEnter(Collider other){
        if(other.CompareTag("Player"))
        {
            anim.SetTrigger("Attack");
        }
    }
}
