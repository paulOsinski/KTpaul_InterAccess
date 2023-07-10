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

    // Start is called before the first frame update
    void Start()
    {
        stoneNum = 0;
        foodNum = 150;
        woodNum = 100;
        goldNum = 0;

        idleVill = 0;
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

}
