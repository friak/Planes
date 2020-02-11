using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class select_vertices : MonoBehaviour
{
    public GameObject paper;
    float threshold = 0.1f;
    List<GameObject> spheres = new List<GameObject>();


    

    // Start is called before the first frame update
    void Start()
    {
        CreateSpheres();
    }

    // Update is called once per frame
    void Update()
    {


    }

    public void CreateSpheres()
    {

        Vector3[] vertices = paper.GetComponent<MeshFilter>().mesh.vertices;

        foreach (Vector3 vert in vertices)
        {
  
            GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            Vector3 WorldPoint = transform.TransformPoint(vert);
            sphere.transform.position = WorldPoint;

            sphere.transform.localScale = new Vector3(.005f, .005f, .005f);
            spheres.Add(sphere);
            //sphere.GetComponent<SphereCollider>().isTrigger = true;
            sphere.GetComponent<Renderer>().enabled = false;
            sphere.AddComponent<selected>();
        }
    }
}
