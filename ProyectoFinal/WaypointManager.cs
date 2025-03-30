using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointManager : MonoBehaviour
{
    public GameObject waypointPrebab;
    public float radius = 5f;
    public int numWaypoints = 3;
    
    public Transform[] createWayPoints (Vector3 center)
    {
        Transform[] waypoints = new Transform[numWaypoints];

        for(int i = 0; i < numWaypoints; i++)
        {
            Vector3 randomPos = Random.insideUnitCircle * radius;
            Vector3 pos = new Vector3(randomPos.x, 0f, randomPos.y) + center;

            GameObject waypointGO = Instantiate(waypointPrebab, pos, Quaternion.identity);
            waypoints[i] = waypointGO.transform;
        }
        return waypoints;
    }
}
