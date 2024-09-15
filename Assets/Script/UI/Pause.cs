using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    public static bool GameIspaused = false;
    public GameObject pauseMenuUI;
    private Follow_Camera PosisiKamera;
    public AudioClip Audioclip;
    public AudioSource ButtonClick;


    // Update is called once per frame
    void Update()
    {
        PosisiKamera = FindObjectOfType<Follow_Camera>();

        if (Input.GetKeyDown(KeyCode.Escape) && PosisiKamera.IsLose == false)
        {
            if (GameIspaused)
            {
                Resume();
            }
            else
            {
                Berhenti();
            }

        }
        
    }

    public void Resume()
    {
        ButtonClick.PlayOneShot(Audioclip);
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIspaused = false;
    }

    public void Berhenti()
    {
        if(PosisiKamera.IsLose == true)
        {
            return;
        }
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIspaused = true;
    }

    public void WinLose()
    {
        Time.timeScale = 0f;
        GameIspaused = true;
    }

    public void RestartLevel()
    {
        ButtonClick.PlayOneShot(Audioclip);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
    }



}
