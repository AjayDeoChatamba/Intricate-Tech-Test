using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UpdateScore : MonoBehaviour
{
    float score = 0;
    [SerializeField] TextMeshProUGUI scoreText;
    GameObject gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager");
    }

    void updateScore()
    {
        score += Time.deltaTime;
        scoreText.text = ((int)score).ToString();
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
