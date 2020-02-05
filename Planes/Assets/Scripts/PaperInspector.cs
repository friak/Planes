using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

[CustomEditor(typeof(PaperMesh))]
public class PapertInspector : Editor
{
    private PaperMesh mesh;
    private Transform handleTransform;
    private Quaternion handleRotation;

    private int selectedIndex = -1;
    private int assignIndex;

    void OnSceneGUI()
    {
        mesh = target as PaperMesh;
        handleTransform = mesh.transform;
        handleRotation = Tools.pivotRotation == PivotRotation.Local ? handleTransform.rotation : Quaternion.identity;

        if (mesh.oVertices == null)
        {
            mesh.Init();
        }

        // Add Points
        if (mesh.editType.ToString() == "AddIndices")
        {
            for (int i = 0; i < mesh.oVertices.Length; i++)
            {
                ShowHandle(i);
            }
        }

        // Show/ Hide Transform Tool
        if (mesh.showTransformHandle)
        {
            Tools.current = Tool.Move;
        }
        else
        {
            Tools.current = Tool.None;
        }
    }

    void ShowHandle(int index)
    {
        Vector3 point = handleTransform.TransformPoint(mesh.oVertices[index]);

        // Unselected vertex
        if (!mesh.selectedIndices.Contains(index))
        {
            if (Handles.Button(point, handleRotation, mesh.pickSize, mesh.pickSize,
                Handles.DotHandleCap)) //1
            {
                mesh.selectedIndices.Add(index);
                Handles.color = Color.blue;
            }
            if (Handles.Button(point, handleRotation, mesh.pickSize, mesh.pickSize, Handles.DotHandleCap))
            {
                selectedIndex = index;
            }

            if (selectedIndex == index)
            {

                if (assignIndex != index)
                {
                    assignIndex = mesh.targetIndex = index;
                    mesh.selectedIndices.Add(index);
                }
            }
        }
    }


    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        mesh = target as PaperMesh;

        if (GUILayout.Button("Clear Selected Vertices"))
        {
            Debug.Log("Editor Reset");
            assignIndex = 0;
            selectedIndex = -1;
            mesh.ClearAllData();
        }
    }
}
