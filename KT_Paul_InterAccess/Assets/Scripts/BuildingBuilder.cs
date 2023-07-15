using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingBuilder : MonoBehaviour
{
    public GameObject building;
    public GameObject buildingFarm;
    public GameObject buildingWoodCamp;
    public GameObject buildingStoneMine;
    public GameObject buildingGoldMine;
    public GameObject buildingMilitary;

    public PlayerControls playerControls;
    public GameObject currentBuild;
    public ResourceManager resourceManager;

    public string buildingStatus;

    public Material invalidMaterial;
    public Material validMaterial;
    public Material fixedMaterial;

    BuildingObject currentBuildData;
    GameObject currentBuildSprite;
    string currentBuildType = "none";

    Vector3 buildingPos;



    public void createBuilding()
    {
    

        if (currentBuildType != "house")
        {
            Debug.Log("createBuilding Called");

            buildingPos = playerControls.worldPosition;

            currentBuild = GameObject.Instantiate(building, buildingPos, Quaternion.identity);
            currentBuildData = currentBuild.GetComponent<BuildingObject>();
            currentBuildSprite = currentBuild.transform.GetChild(0).gameObject;

            currentBuildType = currentBuild.GetComponent<BuildingObject>().buildingType;
        }

    }

    public void createBuildingFarm()
    {

        if ( currentBuildType != "farm" || currentBuild == null)
        {
            Debug.Log("Farm created");

            Vector3 buildingPos = playerControls.worldPosition;

            currentBuild = GameObject.Instantiate(buildingFarm, buildingPos, Quaternion.identity);
            currentBuildData = currentBuild.GetComponent<BuildingObject>();
            currentBuildSprite = currentBuild.transform.GetChild(0).gameObject;

            currentBuildType = currentBuild.GetComponent<BuildingObject>().buildingType;
        }
    }


    public void createBuildingWood()
    {

        if (currentBuildType != "wood" || currentBuild == null)
        {
            Debug.Log("wood c amp created");

            Vector3 buildingPos = playerControls.worldPosition;

            currentBuild = GameObject.Instantiate(buildingWoodCamp, buildingPos, Quaternion.identity);
            currentBuildData = currentBuild.GetComponent<BuildingObject>();
            currentBuildSprite = currentBuild.transform.GetChild(0).gameObject;

            currentBuildType = currentBuild.GetComponent<BuildingObject>().buildingType;
        }
    }

    public void createBuildingStoneMine()
    {

        if (currentBuildType != "stone")
        {
            Debug.Log("stone mine createcd");

            Vector3 buildingPos = playerControls.worldPosition;

            currentBuild = GameObject.Instantiate(buildingStoneMine, buildingPos, Quaternion.identity);
            currentBuildData = currentBuild.GetComponent<BuildingObject>();
            currentBuildSprite = currentBuild.transform.GetChild(0).gameObject;

            currentBuildType = currentBuild.GetComponent<BuildingObject>().buildingType;

        }
    }

    public void createBuildingGoldMine()
    {

        if (currentBuildType != "gold")
        {
            Debug.Log("gold mine built");

            Vector3 buildingPos = playerControls.worldPosition;

            currentBuild = GameObject.Instantiate(buildingStoneMine, buildingPos, Quaternion.identity);
            currentBuildData = currentBuild.GetComponent<BuildingObject>();
            currentBuildSprite = currentBuild.transform.GetChild(0).gameObject;

            currentBuildType = currentBuild.GetComponent<BuildingObject>().buildingType;
        }
    }

    public void createBuildingMilitary()
    {

        if (currentBuildType != "mil")
        {
            Debug.Log("mil build called");

            Vector3 buildingPos = playerControls.worldPosition;

            currentBuild = GameObject.Instantiate(buildingMilitary, buildingPos, Quaternion.identity);
            currentBuildData = currentBuild.GetComponent<BuildingObject>();
            currentBuildSprite = currentBuild.transform.GetChild(0).gameObject;

            currentBuildType = currentBuild.GetComponent<BuildingObject>().buildingType;
        }
    }


    void Update()
    {
        buildingPos = playerControls.worldPosition;

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

                    if (currentBuildType == "farm")
                    {
                        resourceManager.farmCheck = true;
                    }
                    else if (currentBuildType == "wood")
                    {
                        resourceManager.woodCampCheck = true;
                    }
                    else if (currentBuildType == "stone")
                    {
                        resourceManager.stoneMineCheck = true;
                    }
                    else if (currentBuildType == "gold")
                    {
                        resourceManager.goldMineCheck = true;
                    }
                    else if (currentBuildType == "house")
                    {
                        resourceManager.houseCheck = true;
                    }
                    else

                        Debug.Log("no build type found");

                    currentBuild = null;
                    currentBuildSprite.GetComponent<SpriteRenderer>().material = fixedMaterial;
                    Debug.Log("building fixed ");
                    currentBuildType = "none";
                }
            }
        }

        // update building status
        // if (buildingPos does not collide w. obstacles + required resources are met) status = valid
        //if (required resources are not met and/or buildingPos collides w. obstacles) status = invalid
       
    }

}
