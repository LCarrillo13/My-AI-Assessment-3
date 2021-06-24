using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class AgentObject : MonoBehaviour
{
    private WaypointScript[] waypoints;
    private NavMeshAgent agent;

    private WaypointScript RandomWaypoint => waypoints[Random.Range(0, waypoints.Length)];
    // Start is called before the first frame update
    void Start()
    {
        agent = gameObject.GetComponent<NavMeshAgent>();
        waypoints = FindObjectsOfType<WaypointScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!agent.pathPending && agent.remainingDistance < 0.1f)
        {
            agent.SetDestination(RandomWaypoint.Position);
        }
    }
}
