using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshResearch : MonoBehaviour
{

    private void Awake()
    {
        MeshFilter meshFilter = GetComponent<MeshFilter>();
        MeshRenderer meshRenderer = GetComponent<MeshRenderer>();

        Mesh mesh = meshFilter.sharedMesh;


        foreach (var item in mesh.triangles)
        {
            Debug.Log($"item: {item}");
        }
    }

    private void OnDrawGizmos()
    {
        MeshFilter meshFilter = GetComponent<MeshFilter>();
        MeshRenderer meshRenderer = GetComponent<MeshRenderer>();

        Mesh mesh = meshFilter.sharedMesh;

        Gizmos.color = Color.green;


        foreach (var item in mesh.vertices)
        {
            Gizmos.DrawSphere(item, 0.05f);
        }


       

        int index = 0;

        while(index < mesh.triangles.Length)
        {
            int vertexIndex0 = mesh.triangles[index];
            int vertexIndex1 = mesh.triangles[index + 1];
            int vertexIndex2 = mesh.triangles[index + 2];

            Vector3 vertex0 = mesh.vertices[vertexIndex0];
            Vector3 vertex1 = mesh.vertices[vertexIndex1];
            Vector3 vertex2 = mesh.vertices[vertexIndex2];

            Gizmos.color = Color.red;
            Gizmos.DrawLine(vertex0, vertex1);
            Gizmos.color = Color.blue;
            Gizmos.DrawLine(vertex1, vertex2);
            Gizmos.color = Color.yellow;
            Gizmos.DrawLine(vertex2, vertex0);

            index += 3;
        }
       
    }
}
