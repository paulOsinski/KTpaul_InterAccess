using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetVilTarget : MonoBehaviour
{
    [SerializeField] private Pathfinding.AIDestinationSetter aIDestinationSetter;

    private GameObject target;

    // Start is called before the first frame update
    void Start()
    {        
    }

    // Update is called once per frame
    void Update()
    {        
        target = GameObject.FindGameObjectWithTag("TaskObject");
        if (target != null)
        {aIDestinationSetter.target = target.transform;
        Debug.Log("new task object found");}
        else
        {
            Debug.Log("no task object found");
        }
        
    }
}