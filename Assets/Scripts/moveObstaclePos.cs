using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveObstaclePos : MonoBehaviour
{
    float RandomPosi;
    [SerializeField]float timeToChangeSpawnPosition;
    float timer;


    // Start is called before the first frame update
    void Start()
    {
        timer = timeToChangeSpawnPosition;        
    }

    // Update is called once per frame
    void Update()
    {
           timer -= Time.deltaTime;
        if(timer < 0)
        {
            RandomPosi = Random.Range(-1.5f, 1.5f);
            transform.position += new Vector3(0, RandomPosi, 0);
            timer = timeToChangeSpawnPosition;
        }

        //if the obstacle is spawned too high or too low
        if (transform.position.y > 3)
        {
            transform.position = new Vector3(transform.position.x, 0, transform.position.z);
        }
        if (transform.position.y < -3)
        {
            transform.position = new Vector3(transform.position.x, 0, transform.position.z);
        }

    }
}
