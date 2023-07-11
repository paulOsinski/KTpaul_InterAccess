using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class VillagerAI : MonoBehaviour
{

    public Transform target;

    public float speed = 200f;
    public float nextWaypointDistance = 3f;

    Path path;
    int currentWaypoint = 0;
    bool reachedEndOfPath = false;

    Seeker seeker;
    Rigidbody2D rigidBod;

    // Start is called before the first frame update
    void Start()
    {
        seeker = GetComponent<Seeker>();
        rigidBod = GetComponent<Rigidbody2D>();

        seeker.StartPath(rigidBod.position, target.position, OnPathComplete);
    }

    void OnPathComplete(Path p)
    {
        if(!p.error)
        {
            path = p;
            currentWaypoint = 0;
            reachedEndOfPath = false;
            return;
        }
    }
     

    // Update is called once per frame
    void Update()
    {
        if (path == null)
            return;
        
        if(currentWaypoint >= path.vectorPath.Count)
        {
            reachedEndOfPath = true;
            return;
        } else
        {
            reachedEndOfPath = false;
        }

        Vector2 direction = ((Vector2)path.vectorPath[currentWaypoint] - rigidBod.position).normalized;
        Vector2 force = direction * speed * Time.deltaTime;
        
        rigidBod.AddForce(force);
        float distance = Vector2.Distance(rigidBod.position, path.vectorPath[currentWaypoint]);

        if (distance < nextWaypointDistance)
        {
            currentWaypoint++;
            return;
        }
    }
}