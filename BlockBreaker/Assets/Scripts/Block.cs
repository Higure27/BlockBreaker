using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    //Config Params
    [SerializeField] private AudioClip collisionSound = default;
    [SerializeField] private GameObject blockSparkVFX = default;
    //Length detrmines how many hits block can take before breaking
    [SerializeField] private Sprite[] damageSprites = default;
    private int maxHits;

    // Cached refs
    private LevelManager levelManager;

    //State Vars
    [SerializeField] private int currHitCounter;//TODO: Serialized for debugging

    private void Start()
    {
        levelManager = default;
        maxHits = damageSprites.Length;
        CountBreakableBlocks();
        currHitCounter = 0;
    }

    private void CountBreakableBlocks()
    {
        if (tag == "Breakable")
        {
            levelManager = FindObjectOfType<LevelManager>();
            levelManager.CountBlock();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (tag == "Breakable")
        {
            currHitCounter++;
            if (currHitCounter >= maxHits)
            {
                TriggerSparkVFX();
                DestroyBlock();
            }
            else
            {
                ShowNextDamageSprite();
            }
        }
    }

    private void ShowNextDamageSprite()
    {

        if (currHitCounter < maxHits)
        {
            GetComponent<SpriteRenderer>().sprite = damageSprites[currHitCounter];
        }
        else
        {
            //Will get highest damage sprite 
            GetComponent<SpriteRenderer>().sprite = damageSprites[maxHits - 1];
        }
    }

    private void DestroyBlock()
    {
        AudioSource.PlayClipAtPoint(collisionSound, Camera.main.transform.position,0.8f);
        levelManager.CountBlocksDestroyed();
        //Destroy this object
        Destroy(gameObject);
    }

    private void TriggerSparkVFX()
    {
        GameObject SparkVFX = Instantiate(blockSparkVFX,transform.position,transform.rotation);
        Destroy(SparkVFX, 1f);
    }
}
