using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarsManager : MonoBehaviour
{
    public static StarsManager Instance;
    //public LevelStars[] level;
    public int[] stars;

    private void Awake()
    {
        //PlayerPrefs.DeleteAll();
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }

        else if (Instance != this) Destroy(this);
    }

}
