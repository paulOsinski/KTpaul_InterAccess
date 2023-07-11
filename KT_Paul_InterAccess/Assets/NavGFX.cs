using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class NavGFX : MonoBehaviour
{
    public AIPath aiPath;


    // Update is called once per frame
    void Update()
    {
            if(aiPath.desiredVelocity.x >= 0.01f)
            // travelling to the left
            {
                Debug.Log("we're going right");
                transform.localScale = new Vector3(1f, 1f, 1f);
            }
            else if (aiPath.desiredVelocity.x <= -0.01f)
            {
                Debug.Log("we're going left");
            // travelling to the right
                transform.localScale = new Vector3(-1f, 1f, 1f);
            }
            else
            {
                Debug.Log("we're going straight or stopped");
            }

        }
        
    }

