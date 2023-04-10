using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float timeToDestroy;
    float obstacleLife;
    GameObject gameManager;

    //random scaling for obstacles
    float randomScaleY;

    [SerializeField]  float speedChangeAfterTime;
    float timer;

    // Start is called before the first frame update
    void Start()
    {
        randomScaleY = Random.Range(1, 2f);
        transform.localScale = new Vector3(1, randomScaleY, 1);

        obstacleLife = timeToDestroy;
        gameManager = GameObject.Find("GameManager");

        timer = speedChangeAfterTime;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * Time.deltaTime * speed);

        //Countdown to destroy the object after sometime
        obstacleLife -= Time.deltaTime;
        if(obstacleLife < 0 || gameManager.GetComponent<GameManager>().gameOver)
        {
            obstacleLife = timeToDestroy;
            gameObject.SetActive(false);
        }


        //increase speed after sometime
        timer -= Time.deltaTime;
        if (timer < 0)
        {
            speed += 4;
            timer = speedChangeAfterTime; 
        }

    }
    
}
