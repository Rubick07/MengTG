using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Build_Manager : MonoBehaviour
{
    public static Build_Manager Instance;
    private GameObject turretToBuild;
    private void Awake()
    {
        if(Instance != null)
        {
            Debug.LogError("Build manager lebih dari 1");
        }
        Instance = this;
    }

    public GameObject StandardTurretPrefab;

    void Start()
    {
        turretToBuild = StandardTurretPrefab;
    }


    public GameObject GetTurretToBuild()
    {
        return turretToBuild;
    }

}
