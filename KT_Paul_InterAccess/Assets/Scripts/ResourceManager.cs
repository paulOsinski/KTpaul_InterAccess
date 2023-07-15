using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ResourceManager : MonoBehaviour
{
    public int stoneNum;
    public int foodNum;
    public int woodNum;
    public int goldNum;

    public int idleVill;

    public TMP_Text woodCostText;
    public TMP_Text stoneCostText;
    public TMP_Text goldCostText;
    public TMP_Text foodCostText;
    public TMP_Text idleVillText;

    public bool stoneMineCheck;
    public bool woodCampCheck;
    public bool goldMineCheck;
    public bool farmCheck;
    public bool houseCheck;

    // Start is called before the first frame update
    void Start()
    {
        stoneNum = 25;
        foodNum = 150;
        woodNum = 200;
        goldNum = 0;
        idleVill = 0;

        InvokeRepeating("ResourceAdd", 2f, 2f);  //1s delay, repeat every 1s
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("wood: " + woodNum + "stone: " + stoneNum + "food: " + foodNum + "gold: " + goldNum);

        woodCostText.SetText("Wood: " + woodNum);
        foodCostText.SetText("Food: " + foodNum);
        stoneCostText.SetText("Stone: " + stoneNum);
        goldCostText.SetText("Gold: " + goldNum);

        idleVillText.SetText("Idle: " + idleVill);

    }

    void ResourceAdd()
    {
        foodNum = foodNum - 1;

        Debug.Log(Time.time);
        if (farmCheck == true && foodNum < 400)
        {
            foodNum = foodNum + 2;
        }
        if (woodCampCheck && woodNum < 300)
        {
            woodNum = woodNum +3;
        }
        if (goldMineCheck && goldNum < 100)
        {
            goldNum = goldNum + 1;
        }
        if (stoneMineCheck && stoneNum < 200)
        {
            stoneNum = stoneNum + 2;
        }

    }
}
