using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waypointMoverCar : MonoBehaviour
{
    [SerializeField]
    private WaypointCar waypoints;

    [SerializeField]
    private float moveSpeed = 10f;

    [SerializeField]
    private float distanceThreshold = 0.1f;

    private Transform currentWaypoint;
    // Start is called before the first frame update
    void Start()
    {
        currentWaypoint = waypoints.GetNextWaypoint(currentWaypoint);
        transform.position = currentWaypoint.position;

        currentWaypoint = waypoints.GetNextWaypoint(currentWaypoint);
        transform.LookAt(currentWaypoint);

        moveSpeed = 10f;

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, currentWaypoint.position, moveSpeed * Time.deltaTime);
        if (Vector3.Distance(transform.position, currentWaypoint.position) < distanceThreshold)
        {
            currentWaypoint = waypoints.GetNextWaypoint(currentWaypoint);
            transform.LookAt(currentWaypoint);
        }
    }

}
