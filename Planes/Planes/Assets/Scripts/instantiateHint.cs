using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class instantiateHint : MonoBehaviour
{
   
    public GameObject Puzzle;
    public GameObject Paper;
    public GameObject PaperL;
    public GameObject PaperR;

    public GameObject Hint;
    public GameObject donePaper;
    public GameObject doneSil;


    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("I have entered trigger");
        GameObject otherGO = other.gameObject;

        if (otherGO.name == "grababble_handler")
        {
            FindObjectOfType<SoundManager>().Play("next");
            Puzzle.SetActive(true);
            Paper.SetActive(true);
            PaperL.SetActive(true);
            PaperR.SetActive(true);
            Hint.SetActive(true);
            Destroy(donePaper);
            Destroy(doneSil);
        }

    }
}
