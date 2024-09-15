using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Level_Manager : MonoBehaviour
{
    public Button[] buttons;
    public LevelStars[] levelStars;
    public AudioClip audioClip;
    void Start()
    {
        //PlayerPrefs.DeleteAll();

        int levelAt = PlayerPrefs.GetInt("LevelAt", 2);

        for(int i = 0; i < buttons.Length; i++)
        {

            if(i+2 > levelAt)
            {

                buttons[i].interactable = false;

            }

            for(int j = 0; j< StarsManager.Instance.stars[i]; j++)
            {
                levelStars[i].Stars[j].enabled = true;
            }
            

        }
    }



}
