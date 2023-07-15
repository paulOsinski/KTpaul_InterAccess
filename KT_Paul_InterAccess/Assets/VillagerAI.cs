using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class VillagerAI : MonoBehaviour
{

    public Transform target;

    public float speed = 200f;
    public float nextWaypointDistance = 3f;

    public Transform enemyGFX;

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

        InvokeRepeating("UpdatePath", 0f, .5f);
    }

    void UpdatePath()
    {
        if(seeker.IsDone())
        {
        seeker.StartPath(rigidBod.position, target.position, OnPathComplete);
        }
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

        if(rigidBod.velocity.x >= 0.01f)
            // travelling to the left
            {
                enemyGFX.localScale = new Vector3(1f, 1f, 1f);
            }
        else if (rigidBod.velocity.x <= -0.01f)

            {
                enemyGFX.localScale = new Vector3(-1f, 1f, 1f);
            }
    }
}