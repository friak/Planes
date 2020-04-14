using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bg_rotation : MonoBehaviour
{
    public float speed = 10f; //degrees per second

    void Update()
    {
        transform.RotateAround(transform.position, transform.up, Time.deltaTime * speed);
    }

}
