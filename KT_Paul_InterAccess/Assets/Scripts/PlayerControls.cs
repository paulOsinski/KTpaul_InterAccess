using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{

    public Vector3 screenPosition;
    public Vector3 worldPosition;

    // Start is called before the first frame update
    void Start()
    {
       

    

    }

    // Update is called once per frame
    void Update()
    {
        screenPosition = Input.mousePosition;
        worldPosition = Camera.main.ScreenToWorldPoint(screenPosition + new Vector3(0, 0, 20f));

        

    }

    private void OnMouseDown()
    {
        //check if click is on an interactble object in game world
        //could be person, building, 
    }

}
