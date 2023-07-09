using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingBuilder : MonoBehaviour
{
    public GameObject building;
    public PlayerControls playerControls;
    public GameObject currentBuild;

    string buildingStatus;

    // Start is called before the first frame update
    public void createBuilding()
    {
        Debug.Log("createBuilding Called");

        Vector3 buildingPos = playerControls.worldPosition;

        currentBuild = GameObject.Instantiate(building, buildingPos, Quaternion.identity);
        
    }

    // Update is called once per frame
    void Update()
    {

        if (currentBuild != null)
        {
            Vector3 buildingPos = playerControls.worldPosition; 

            currentBuild.transform.position = buildingPos; //move building w. mouse

            if (Input.GetMouseButtonDown(0))
            {
                //if status = valid, status = fixed
                //place building

                buildingStatus = "fixed";

                if (buildingStatus == "fixed")
                {
                    currentBuild = null;
                    Debug.Log("building fixed ");
                }
            }
        }

        // update building status
        // if (buildingPos does not collide w. obstacles + required resources are met) status = valid
        //if (required resources are not met and/or buildingPos collides w. obstacles) status = invalid
       
    }

}
