using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackTrigger : MonoBehaviour
{
   public void OnTriggerEnter(Collider other){

      if(other.CompareTag("Player"))
      {
      
      }
   }
}
