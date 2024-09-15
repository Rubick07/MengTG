using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower_Ballista : MonoBehaviour
{


    [Header("Attributes")]
    public float range = 15f;
    public float firerate = 1f;
    public float x;
    public float y;
    private float firecountdown = 0f;

    [Header("Unity Setup Fields")]
    public GameObject bulletPrefab;
    public Transform firepoint;
    public Animator animator;
    public AudioSource reload;
    public AudioSource Tembak;
    GameObject tembak;



    void Start()
    {
        // update range;

    }

    // Update is called once per frame
    void Update()
    {
        //Buat Nembak
        if (firecountdown <= 0f)
        {
            animator.SetTrigger("Tembak");
            firecountdown = 1f / firerate;

        }

        firecountdown -= Time.deltaTime;


        //Testing
        /*if (Input.GetKeyDown(KeyCode.Space))
        {
            tembak = (GameObject)Instantiate(bulletPrefab, firepoint.position, firepoint.rotation);
        }
        */
    }

    public void SpawnBullet()
    {
        Tembak.enabled = false;
        Tembak.enabled = true;
        tembak = (GameObject)Instantiate(bulletPrefab, firepoint.position, firepoint.rotation);
        Ballista ballista = tembak.GetComponent<Ballista>();
        ballista.posisiAwal = transform;
        tembak.transform.SetParent(firepoint.transform);
    }

    public void ReloadBUllet()
    {
        reload.enabled = false;
        reload.enabled = true;

    }


    /*   private void OnDrawGizmosSelected()
       {
           Gizmos.color = Color.red;
           Gizmos.DrawSphere(transform.position, range);
       }
    */
}
