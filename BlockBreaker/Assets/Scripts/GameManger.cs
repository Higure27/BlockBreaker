using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManger : MonoBehaviour
{
    //Config Params
    [Range(.1f,2f)][SerializeField] private float gameTimeScale = 1f;
    [SerializeField] private int pointsPerBlock = 10;
    [SerializeField] private TextMeshProUGUI scoreText = default;
    [SerializeField] private bool autoPlay;

    //State Vars
    private int playerScore = 0;

    private void Awake()
    {
        int gameManagerCount = FindObjectsOfType<GameManger>().Length;
        if(gameManagerCount > 1)
        {
            //As destroy happens at the end of cycle this avoids from other objects using this game manager
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Start()
    {
        //TODO: Find scoreText object instead
        scoreText.text = playerScore.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        Time.timeScale = gameTimeScale;
    }

    public void AddToScore()
    {
        playerScore += pointsPerBlock;
        scoreText.text = playerScore.ToString();
    }

    //Called only when game restarts to start screen
    public void SelfDestruct()
    {
        Destroy(gameObject);
    }

    public bool IsAutoPlayEnabled()
    {
        return autoPlay;
    }
}
