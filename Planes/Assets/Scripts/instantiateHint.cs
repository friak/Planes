using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class instantiateHint : MonoBehaviour
{
    public GameObject target;
    public GameObject Hint;
    public GameObject donePaper;
    public GameObject doneSil;


    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("I HAVE enetered'");
        GameObject otherGO = other.gameObject;

        if (otherGO.name == "grababble_handler")
        {
            FindObjectOfType<SoundManager>().Play("next");
            Instantiate(Hint, target.transform.position, Quaternion.identity);
            Destroy(donePaper);
            Destroy(doneSil);
        }

    }
}
