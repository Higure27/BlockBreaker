using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField] float screenWidthUnits = 16f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //X position relative to screen size
        float mousePosX = Input.mousePosition.x / Screen.width * screenWidthUnits;
        Vector2 padPosition = new Vector2(mousePosX, transform.position.y);
        transform.position = padPosition;
    }
}
