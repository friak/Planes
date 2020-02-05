using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PaperMesh : MonoBehaviour
{
    Mesh oMesh;
    Mesh cMesh;
    MeshFilter oFilter;

    [HideInInspector]
    public int targetIndex;

    [HideInInspector]
    public Vector3 targetVertex;

    [HideInInspector]
    public Vector3[] oVertices;

    [HideInInspector]
    public Vector3[] modifiedVertices;

    [HideInInspector]
    public Vector3[] normals;

    // For Editor
    public enum EditType
    {
        AddIndices, None
    }

    public EditType editType;

    public bool showTransformHandle = true;
    public List<int> selectedIndices = new List<int>();
    public float pickSize = 0.01f;

    // Deforming settings
    public float radiusofeffect = 0.3f;
    public float pullvalue = 0.3f;

    // Animation settings
    public float duration = 1.2f;
    bool isAnimate = false;
    float starttime = 0f;
    float runtime = 0f;
    int currentIndex = 0;

    public GameObject Win;



    void Start()
    {
        Init();
    }

    public void Init()
    {
        oFilter = GetComponent<MeshFilter>();
        currentIndex = 0;

        if (editType == EditType.AddIndices)
        {
            oMesh = oFilter.sharedMesh;
            cMesh = new Mesh();
            cMesh.name = "clone";
            cMesh.vertices = oMesh.vertices;
            cMesh.triangles = oMesh.triangles;
            cMesh.normals = oMesh.normals;
            oFilter.mesh = cMesh;

            // update local variables...
            oVertices = cMesh.vertices;

            normals = cMesh.normals;
            Debug.Log("Init & Cloned");
        }
        else
        {
            oMesh = oFilter.sharedMesh;
            oVertices = oMesh.vertices;

            normals = oMesh.normals;
            modifiedVertices = new Vector3[oVertices.Length];
            for (int i = 0; i < oVertices.Length; i++)
            {
                modifiedVertices[i] = oVertices[i];
            }

            StartDisplacement();
        }
    }

    public void StartDisplacement()
    {
        targetVertex = modifiedVertices[selectedIndices[currentIndex]];
        starttime = Time.time;
        isAnimate = true;
    }

    void FixedUpdate()
    {
        if (!isAnimate)
        {
            return;
        }

        runtime = Time.time - starttime;

        if (runtime < duration)
        {
            Vector3 relativePoint = oFilter.transform.InverseTransformPoint(targetVertex);
            DisplaceVertices(relativePoint, pullvalue, radiusofeffect);
        }
        else
        {
            currentIndex++;
            if (currentIndex < selectedIndices.Count)
            {
                StartDisplacement();
                Debug.Log("next");
            }
            else
            {
                oMesh = GetComponent<MeshFilter>().sharedMesh;
                isAnimate = false;
                Debug.Log("done");
            }
        }

        if (11 == selectedIndices.Count)
        {
            Instantiate(Win, new Vector3(0, 0, 0), Quaternion.identity);
        }
    }

    void DisplaceVertices(Vector3 pos, float force, float radius)
    {
        Vector3 vert = Vector3.zero;
        float sqrRadius = radius * radius;

        for (int i = 0; i < modifiedVertices.Length; i++)
        {
            float sqrMagnitude = (modifiedVertices[i] - pos).sqrMagnitude;
            if (sqrMagnitude > sqrRadius)
            {
                continue;
            }
            vert = modifiedVertices[i];

            float distance = Mathf.Sqrt(sqrMagnitude);

        }
        oMesh.vertices = modifiedVertices;
        oMesh.RecalculateNormals();
    }

    public void ClearAllData()
    {
        Destroy(Win);
        selectedIndices = new List<int>();
        targetIndex = 0;
        targetVertex = Vector3.zero;
    }

    void CurveType1()
    {
    }

    void CurveType2()
    {
    }
}

