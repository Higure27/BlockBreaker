using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    //Configuration Parameters
    [SerializeField] float screenWidthUnits = 16f;
    [SerializeField] float minOnScreenX = 1f;
    [SerializeField] float maxOnScreenX = 15f;

    //Cached Ref
    private Ball levelBall;
    private GameManger gameManger;

    // Start is called before the first frame update
    void Start()
    {
        levelBall = FindObjectOfType<Ball>();
        gameManger = FindObjectOfType<GameManger>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 padPosition = new Vector2(transform.position.x, transform.position.y);
        padPosition.x = Mathf.Clamp(GetXPosition(), minOnScreenX, maxOnScreenX);
        transform.position = padPosition;
    }

    //Retruns either mouse or ball x position, depending if autoPlay is enabled in the GameManager 
    private float GetXPosition()
    {
        if(gameManger.IsAutoPlayEnabled())
        {
            //Ball X position
            return levelBall.transform.position.x;
        }
        else
        {   // Mouse X position - X position relative to screen size
            return Input.mousePosition.x / Screen.width * screenWidthUnits;
        }
    }
}
