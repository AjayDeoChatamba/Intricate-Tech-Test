using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{

    //for pooling of obstacles
    public static GameManager SharedInstance;
    public List<GameObject> pooledObjects;
    public GameObject obstaclePrefab;      //Obstacles
    public int amountToPool;

    GameObject obstacle;

    //to check gameOver
    public bool gameOver;

    //for activating the obstacles
    [SerializeField] GameObject obstabcleSpawnPosition;
    private Vector3 spawnPos;

    //for spawning obstacles
    [SerializeField] int startDelay;
    [SerializeField] int repeatRate;

    //updateScore
    GameObject UI;
    public float score = 0;

    //backgroundMusic
    AudioSource backGroundMusic;

    //for gameover
    public GameObject gameOverScreen;

    void Awake()
    {
        SharedInstance = this;
    }
    
    // Start is called before the first frame update
    void Start()
    {
        //backgroundMusic
        backGroundMusic = GetComponent<AudioSource>();
        backGroundMusic.Play();
       UI = GameObject.Find("Canvas");

        spawnPos = obstabcleSpawnPosition.transform.position;

        //instantiating objects for pooling
        pooledObjects = new List<GameObject>();
        GameObject tmp;
        for (int i = 0; i < amountToPool; i++)
        {
            tmp = Instantiate(obstaclePrefab);
            tmp.SetActive(false);
            pooledObjects.Add(tmp);
        }

        InvokeRepeating("spawnObstacle", startDelay, repeatRate);
    }

    //to get pooledObjects
    GameObject GetPooledObject()
    {
        for (int i = 0; i < amountToPool; i++)
        {  
            if(!gameOver)
            {
                if (!pooledObjects[i].activeInHierarchy)
                {
                    return pooledObjects[i];
                }
            }
            
        }

        return null;
    }

    //spawnObstacle after getting from pool
    void spawnObstacle()
    {
        obstacle = GetPooledObject();
        if (obstacle != null)
        {
            obstacle.SetActive(true);
            obstacle.transform.position = spawnPos;
        }
    }

    //updating score based on how long the player doesnot trigger gameOver
    public void updateScore()
    {
        score += 1;
        //score += Time.deltaTime;
        UI.GetComponentInChildren<TextMeshProUGUI>().text = ((int)score).ToString();
        //UI.GetChildByName<TextMeshProUGUI>("ScoreNumber").text = ((int)score).ToString();
    }

    void showGameOverScreen()
    {
        gameOverScreen.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {        
        if(gameOver)
        {
            showGameOverScreen();
            backGroundMusic.Stop();
        }

        //updating spawn position
        spawnPos = obstabcleSpawnPosition.transform.position;
    }
}
