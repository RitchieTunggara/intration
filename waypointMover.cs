using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waypointMover : MonoBehaviour
{
    [SerializeField]
    private Waypoints waypoints;

    [SerializeField]
    private float moveSpeed = 1f;

    [SerializeField]
    private float distanceThreshold = 0.1f;

    private Transform currentWaypoint;
    private Transform lastWaypoint;

    private bool GameStart;
    [SerializeField]
    public GameObject pickUpPointNPC;
    // Start is called before the first frame update
    void Start()
    {
        GameStart = false;
        currentWaypoint = waypoints.GetNextWaypoint(currentWaypoint);
        transform.position = currentWaypoint.position;

        currentWaypoint = waypoints.GetNextWaypoint(currentWaypoint);
        transform.LookAt(currentWaypoint);

        lastWaypoint = waypoints.GetLastWaypoint();

        moveSpeed = 1f;

        // npcPickUp = GameObject.Find("PickUpPointsNpc").GetComponent<NpcPickUp>();
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

        if (currentWaypoint == lastWaypoint)
        {
            moveSpeed = 0;
        }

    }

    public void Restart()
    {
        currentWaypoint = waypoints.GetFirstWaypoint();
        transform.position = currentWaypoint.position;
        moveSpeed = 1f;
    }
}
