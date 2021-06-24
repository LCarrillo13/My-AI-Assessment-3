using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Agent3Waypoint : MonoBehaviour
{
    public Vector3 Position => transform.position;

    // Implement this OnDrawGizmos if you want to draw gizmos that are also pickable and always drawn
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(Position, 0.5f);


    }
}
