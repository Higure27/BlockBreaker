using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] AudioClip collisionSound;
    LevelManager levelManager;

    private void Start()
    {
        levelManager = FindObjectOfType<LevelManager>();
        levelManager.CountBreakableBlock();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        AudioSource.PlayClipAtPoint(collisionSound, Camera.main.transform.position);
        //Destroy this object
        levelManager.CountBlocksDestroyed();
        Destroy(gameObject);
    }
}
