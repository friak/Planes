using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bg_rotation : MonoBehaviour
{
    public float speed = 5f; //degrees per second

    void Update()
    {
        //transform.RotateAround(transform.position, transform.up, Time.deltaTime * speed);
        transform.Rotate(0, speed, 0 * Time.deltaTime); //rotates 50 degrees per second around z axis
    }

}
