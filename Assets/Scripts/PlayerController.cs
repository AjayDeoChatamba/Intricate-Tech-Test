using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRB;
    [SerializeField] float jumpForce;
    [SerializeField] float gravityModifier;
    GameObject gameManager;
    AudioSource jumpSound;

    // Start is called before the first frame update
    void Start()
    {
        //for player jump and jump sound
        playerRB = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;
        jumpSound = GetComponent<AudioSource>();

        gameManager = GameObject.Find("GameManager");

        //make the player jump once in the start of the game
        playerRB.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
                if(playerRB != null)
            {
                playerRB.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                jumpSound.Play();
            }

        }

        //disable player when its gameover
        if (gameManager != null)
        {
           if(gameManager.GetComponent<GameManager>().gameOver)
            {
                gameObject.SetActive(false);
            }
        }


        //if the player goes to high or too low, the player will be thrusted towards the centre
        if(transform.position.y > 8) 
        {
            if (playerRB != null)
            {
                playerRB.AddForce(Vector3.down * 2, ForceMode.Impulse);
            }
        }

        if (transform.position.y < -5)
        {
            if (playerRB != null)
            {
                playerRB.AddForce(Vector3.up * 2, ForceMode.Impulse);
            }
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Obstacle"))
        {
            if (gameManager != null)
            {
                gameManager.GetComponent<GameManager>().gameOver = true;
                gameObject.SetActive(false);
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Score"))
        { 
            gameManager.GetComponent<GameManager>().updateScore();
        }
    }
}
