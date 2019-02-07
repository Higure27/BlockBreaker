using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    //Configuration Parameters
    [SerializeField] float screenWidthUnits = 16f;
    [SerializeField] float minOnScreenX = 1f;
    [SerializeField] float maxOnScreenX = 15f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //X position relative to screen size
        float mousePosX = Input.mousePosition.x / Screen.width * screenWidthUnits;
        Vector2 padPosition = new Vector2(transform.position.x, transform.position.y);
        padPosition.x = Mathf.Clamp(mousePosX, minOnScreenX, maxOnScreenX);
        transform.position = padPosition;
    }
}
