using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public enum States
{
    None = -1,
    LookingForKey,
    HasKey
}

public class AgentStateTest : MonoBehaviour
{
    [SerializeField]
    private States agentState = States.None;
    //[SerializeField, Range(-3, 3)]
    //private float moveSpeed = 2.753f;
    //[SerializeField, Range(-2, 2)]
    //private float scaleSpeed = 1.0f;
    //[SerializeField, Min(5)]
    //private float rotateSpeed = 5;

    

    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        switch (agentState)
        {
            case States.LookingForKey:
                //

                break;
            case States.HasKey:
                //
                //agent1.SetDestination(RandomWaypoint1.Position);
                break;
            

        }
    }
}