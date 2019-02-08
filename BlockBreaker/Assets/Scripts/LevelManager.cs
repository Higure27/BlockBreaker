using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private int breakableBlocks;//Debuging


    public void CountBreakableBlock()
    {
        breakableBlocks++;
    }

    public void CountBlocksDestroyed()
    {
        breakableBlocks--;
        if (breakableBlocks == 0)
        {
            SceneLoader sceneLoader = FindObjectOfType<SceneLoader>();
            sceneLoader.LoadNextScene();
        }
    }
    private void Awake()
    {
        breakableBlocks = 0;
    }

}
