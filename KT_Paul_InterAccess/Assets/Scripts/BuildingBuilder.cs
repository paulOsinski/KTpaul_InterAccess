using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingBuilder : MonoBehaviour
{
    public GameObject building;
    public PlayerControls playerControls;
    public GameObject currentBuild;
    public ResourceManager resourceManager;

    public string buildingStatus;

    BuildingObject currentBuildData;


    public void createBuilding()
    {
        Debug.Log("createBuilding Called");

        Vector3 buildingPos = playerControls.worldPosition;

        currentBuild = GameObject.Instantiate(building, buildingPos, Quaternion.identity);
        currentBuildData = currentBuild.GetComponent<BuildingObject>();
        
    }



    void Update()
    {

        if (currentBuild != null)
        {

            Vector3 buildingPos = playerControls.worldPosition;

            currentBuild.transform.position = buildingPos; //move building w. mouse


            if (resourceManager.stoneNum < currentBuildData.stoneCost || resourceManager.woodNum < currentBuildData.woodCost || resourceManager.foodNum < currentBuildData.foodCost || resourceManager.goldNum < currentBuildData.goldCost)
            {
                Debug.Log("INVALID BUILDING");

                buildingStatus = "invalid";
                //set material to invalid

            } else
            {
                buildingStatus = "valid";
            }
    

            // if currentBuild collides w. obstacles set to invalid


            if (Input.GetMouseButtonDown(0))
            {
                //if status = valid, status = fixed
                //place building
                if (buildingStatus == "valid") {

                buildingStatus = "fixed";

                Debug.Log(buildingStatus);
                
                    resourceManager.stoneNum = resourceManager.stoneNum - currentBuildData.stoneCost;
                    resourceManager.woodNum = resourceManager.woodNum - currentBuildData.woodCost;
                    resourceManager.foodNum = resourceManager.foodNum - currentBuildData.foodCost;
                    resourceManager.goldNum = resourceManager.goldNum - currentBuildData.goldCost;

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
