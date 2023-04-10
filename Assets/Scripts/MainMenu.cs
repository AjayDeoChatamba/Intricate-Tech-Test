using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    AudioSource clickSound;
    public AudioClip clickClip;
    private void Start()
    {
        clickSound = GetComponent<AudioSource>();
        clickSound.clip = clickClip;
    }

    public void PlayGame()
    {
             SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void PlayAgain()
    {
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void MainMenuButton()
    {
        
        SceneManager.LoadScene("MainMenu");
    }

   public void QuitGame()
    {

        Application.Quit();
    }
}
