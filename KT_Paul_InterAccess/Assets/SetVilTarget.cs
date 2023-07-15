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
        target = GameObject.FindGameObjectWithTag("TaskObject");
        aIDestinationSetter.target = target.transform;
        Debug.Log("WOOHOO");
        
    }

    // Update is called once per frame
    void Update()
    {        
    }
}