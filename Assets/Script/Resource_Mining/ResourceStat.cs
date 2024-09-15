using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceStat : MonoBehaviour
{

    public GameObject drop;
    public GameObject drop_point;
    public int JumlahDrop;
    public int HP = 3;
    public AudioSource Sound;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (HP <= 0)
        {
            for(int i = 0; i< JumlahDrop; i++)
            {
            GameObject Spawn = (GameObject)Instantiate(drop, drop_point.transform);
            Spawn.transform.SetParent(null);
            }

            Destroy(gameObject);
        }

    }

}
