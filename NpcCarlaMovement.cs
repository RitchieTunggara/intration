using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcCarlaMovement : MonoBehaviour
{
    [SerializeField]
    private Waypoints waypoints;

    [SerializeField]
    private float moveSpeed = 5f;

    [SerializeField]
    private float distanceThreshold = 0.1f;

    private Transform currentWaypoint;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
