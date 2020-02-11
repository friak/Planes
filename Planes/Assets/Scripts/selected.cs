using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class selected : MonoBehaviour
{
    private void OnTriggerEnter(Collider trigger)
    {
        Debug.Log("AAAAH");
        if (trigger.transform.gameObject.tag == "hand")
        {
            Debug.Log("YAAAAY");
            this.gameObject.GetComponent<Renderer>().enabled = true;

        }
    }
}
