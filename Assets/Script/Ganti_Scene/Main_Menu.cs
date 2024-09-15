using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main_Menu : MonoBehaviour
{
    public AudioClip Audioclip;
    public AudioSource ButtonClick;
    public void PlayGame(string Stage)
    {
        ButtonClick.PlayOneShot(Audioclip);
        SceneManager.LoadScene(Stage);
    }

    public void QuitGame()
    {
        ButtonClick.PlayOneShot(Audioclip);
        Debug.Log("Keluar");
        Application.Quit();
    }


   

}
