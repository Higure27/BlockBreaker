using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    //Configuration Parameters
    [SerializeField] Paddle paddle1;
    [SerializeField] float ballLaunchVelocityX = 2f;
    [SerializeField] float ballLaunchVelocityY = 18f;
    [SerializeField] AudioClip[] soundFXArray;

    //State
    Vector2 padToBallVector;
    bool ballLaunched = false;

    //Component Ref
    AudioSource ballAudio;

    // Start is called before the first frame update
    void Start()
    {
        padToBallVector = transform.position - paddle1.transform.position;
        ballAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!ballLaunched)
        {
            LockBallToPad();
            LaunchOnClick();
        }

    }

    private void LaunchOnClick()
    {
        if(Input.GetMouseButtonDown(0))
        {
            ballLaunched = true;
            GetComponent<Rigidbody2D>().velocity = new Vector2(ballLaunchVelocityX, ballLaunchVelocityY);
        }
    }

    private void LockBallToPad()
    {
        Vector2 padPos = new Vector2(paddle1.transform.position.x, paddle1.transform.position.y);
        transform.position = padPos + padToBallVector;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(ballLaunched)
        {
            AudioClip soundToPlay = soundFXArray[UnityEngine.Random.Range(0, soundFXArray.Length)];
            ballAudio.pitch = UnityEngine.Random.Range(.5f, 2f);
            ballAudio.volume = UnityEngine.Random.Range(.5f, 1f);
            ballAudio.PlayOneShot(soundToPlay);

        }
    }
}
