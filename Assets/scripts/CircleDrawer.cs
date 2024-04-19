using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleDrawer : MonoBehaviour
{

    private void Awake()
    {
        MeshFilter meshFilter = gameObject.AddComponent<MeshFilter>();
        MeshRenderer meshRenderer = gameObject.AddComponent<MeshRenderer>();

        Mesh mesh = new Mesh();
        Vector3 v1 = new Vector3(0,0,0);
        Vector3 v2 = new Vector3(1,0,0);
        Vector3 v3 = new Vector3(0,1,0);
        /*mesh.vertices = new Vector3[] {v1, v2, v3 };
        mesh.triangles = new int[] {0, 1, 2};

        meshFilter.sharedMesh = mesh;*/


        float delta = 0.01f;
        float radius = 1f;
        List<Vector3> dots = new List<Vector3>();

        for(float x= -radius; x<radius; x += delta)
        {
            float y = Mathf.Sqrt(Mathf.Pow(radius, 2) - Mathf.Pow(x, 2));

            dots.Add(new Vector3(x, y, 0));
            dots.Add(new Vector3(x, -y, 0));
        }

        mesh.vertices = dots.ToArray();



    }



    private void OnDrawGizmos()
    {
        float delta = 0.01f;
        float radius = 1f;
        List<Vector3> dots = new List<Vector3>();

        Gizmos.color = Color.blue;
        for (float x = -1; x < 1; x += delta)
        {
            float y = Mathf.Sqrt(Mathf.Pow(radius, 2) - Mathf.Pow(x, 2));

            dots.Add(new Vector3(x, y, 0));
            dots.Add(new Vector3(x, -y, 0));

            Gizmos.DrawLine(new Vector3(x, y, 0), new Vector3(x, -y, 0));
        }
    }



}
