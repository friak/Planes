using UnityEngine;

public class followPhysics : MonoBehaviour
{

    public Transform target;
    //public GameObject child;
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        Time.fixedDeltaTime = 0.01f;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.MovePosition(target.transform.position);
        //transform.position = child.transform.position;
    }
}
