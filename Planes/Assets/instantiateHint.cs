using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class instantiateHint : MonoBehaviour
{
    public GameObject target;
    public GameObject Hint;
    public GameObject donePaper;
    public GameObject doneSil;

    AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (gameObject.name == "grabbable_handler")
        {
            audioSource.Play();
            Instantiate(target, Hint.transform.position, Quaternion.identity);
            Destroy(donePaper);
            Destroy(doneSil);
        }

    }
}
