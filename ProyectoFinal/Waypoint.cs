using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    public Transform otherWaypoint;
    
    /*private void OnTriggerEnter(Collider hit){
        if(hit.GetComponent<ZombieIA>() != null)
        {
            hit.GetComponent<ZombieIA>().currentWayPoint = otherWaypoint;
        }
    }*/
}
