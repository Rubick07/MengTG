using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow_Camera : MonoBehaviour
{
    public float SmoothSpeed = 0.25f;
    [SerializeField] Vector3 Offset = new Vector3(0, 0, -10f);
    public Transform Target;
    public bool IsLose;
    private Kristal kristal;
    private Player player;

    private Vector3 velocity = Vector3.zero;


    private void FixedUpdate()
    {
        if(IsLose == false)
        {
            transform.position = new Vector3(Target.transform.position.x, Target.transform.position.y, transform.position.z);
        }
        else
        {
            Vector3 newpos = Target.position + Offset;
            transform.position = Vector3.SmoothDamp(transform.position, newpos, ref velocity, SmoothSpeed);
        }

        /*
        Vector3 newpos = Target.position + Offset;
        transform.position = Vector3.SmoothDamp(transform.position, newpos, ref velocity, SmoothSpeed);
        */
        //transform.LookAt(Target);
    }

}
