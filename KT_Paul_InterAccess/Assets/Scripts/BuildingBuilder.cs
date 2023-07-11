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

    public Material invalidMaterial;
    public Material validMaterial;
    public Material fixedMaterial;

    BuildingObject currentBuildData;
    GameObject currentBuildSprite;




    public void createBuilding()
    {
        Debug.Log("createBuilding Called");

        Vector3 buildingPos = playerControls.worldPosition;

        currentBuild = GameObject.Instantiate(building, buildingPos, Quaternion.identity);
        currentBuildData = currentBuild.GetComponent<BuildingObject>();
        currentBuildSprite = currentBuild.transform.GetChild(0).gameObject;

    }

    void Update()
    {

        if (currentBuild != null)
        {

            Vector3 buildingPos = playerControls.worldPosition;

            currentBuild.transform.position = buildingPos; //move building w. mouse


            if (resourceManager.stoneNum < currentBuildData.stoneCost || resourceManager.woodNum < currentBuildData.woodCost || resourceManager.foodNum < currentBuildData.foodCost || resourceManager.goldNum < currentBuildData.goldCost)
            {

                buildingStatus = "invalid";

                currentBuildSprite.GetComponent<SpriteRenderer>().material = invalidMaterial;

                Debug.Log("material set too invalid");

            } else
            {
                buildingStatus = "valid";
                currentBuildSprite.GetComponent<SpriteRenderer>().material = validMaterial;

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
                    currentBuildSprite.GetComponent<SpriteRenderer>().material = fixedMaterial;
                    Debug.Log("building fixed ");
                }
            }
        }

        // update building status
        // if (buildingPos does not collide w. obstacles + required resources are met) status = valid
        //if (required resources are not met and/or buildingPos collides w. obstacles) status = invalid
       
    }

}
