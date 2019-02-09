using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    //State Vars
    private int breakableBlocks = 0;

    GameManger gameManger;

    private void Start()
    {
        gameManger = FindObjectOfType<GameManger>();
    }

    public void CountBlock()
    {
        breakableBlocks++;
    }

    public void CountBlocksDestroyed()
    {
        breakableBlocks--;
        gameManger.AddToScore();
        if (breakableBlocks == 0)
        {
            SceneLoader sceneLoader = FindObjectOfType<SceneLoader>();
            sceneLoader.LoadNextScene();
        }
    }


}
