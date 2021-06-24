using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class AgentTargetWaypoint : MonoBehaviour
{


    //defining the specific waypoints for each agent, calling from the scripts made for each point.
    private WaypointScript[] targetPoint1;
    private Agent2Waypoint[] targetPoint2;
    private Agent3Waypoint[] targetPoint3;

    //defining the key

    private DoorKeyScript doorKey;
    public bool keyCollected = false;


    //defining the agent
    [SerializeField] private NavMeshAgent agent1;
    //[SerializeField] private NavMeshAgent agent2;
    //[SerializeField] private NavMeshAgent agent3;

    //defining 3 different Random Waypoint possibilities, 1 for each of the 3 agents
    private WaypointScript RandomWaypoint1 => targetPoint1[Random.Range(0, targetPoint1.Length)];
    private Agent2Waypoint RandomWaypoint2 => targetPoint2[Random.Range(0, targetPoint2.Length)];
    private Agent3Waypoint RandomWaypoint3 => targetPoint3[Random.Range(0, targetPoint3.Length)];

    // Start is called before the first frame update
    void Start()
    {

        //agent 1 defined as the specific agent in the gameobject
        //defining the target points to the Transform each of the scripts define

        agent1 = gameObject.GetComponent<NavMeshAgent>();
        targetPoint1 = FindObjectsOfType<WaypointScript>();
        targetPoint2 = FindObjectsOfType<Agent2Waypoint>();
        targetPoint3 = FindObjectsOfType<Agent3Waypoint>();
    }

    // Update is called once per frame
    void Update()
    {

        
        if (!agent1.pathPending && agent1.remainingDistance < 0.1f && agent1.tag == "Agent1")
        {
            agent1.SetDestination(RandomWaypoint1.Position);
            if (agent1.pathStatus == NavMeshPathStatus.PathPartial)
            {
                agent1.SetDestination(doorKey.Position);
                if(keyCollected == true)
                {
                    agent1.SetDestination(RandomWaypoint1.Position);
                }
                  
            }
            else if(agent1.pathStatus == NavMeshPathStatus.PathComplete)
            {
                agent1.SetDestination(RandomWaypoint1.Position);
            }
            
        }

        if (!agent1.pathPending && agent1.remainingDistance < 0.1f && agent1.tag == "Agent2")
        {
            agent1.SetDestination(RandomWaypoint2.Position);
        }

        if (!agent1.pathPending && agent1.remainingDistance < 0.1f && agent1.tag == "Agent3")
        {
            agent1.SetDestination(RandomWaypoint3.Position);
        }


    }
}
