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
        Debug.Log("player control script");

    }

    // Update is called once per frame
    void Update()
    {
        screenPosition = Input.mousePosition;

        Ray ray = Camera.main.ScreenPointToRay(screenPosition);

    }

    private void OnMouseDown()
    {
        Debug.Log("mouse clicked");
    }
}
