using System;
using System.Collections.Generic;
using System.Linq;
//using Unity.Mathematics;
using UnityEngine;
//using Random = Unity.Mathematics.Random;

public class SphereGeneratorComponent : MonoBehaviour
{
    
        public int acuracy = 10;
        public float radius = 1f;
        private Mesh mesh;
        private void Awake()
        {
            
            sphere();


        }
    
        
        public void sphere()
        {
            Mesh mesh = GetComponent<MeshFilter>().mesh;
            int accuracy = acuracy + 1;

            List<Vector3> listVertices = new List<Vector3>();
            List<int> listTriangles = new List<int>();
            
            float[] phi = linspace(0, (float)Math.PI, accuracy);
            float[] theta = linspace(0, 2*(float)Math.PI, accuracy);
            
            double[,] x = new double[accuracy, accuracy];
            double[,] y = new double[accuracy, accuracy];
            double[,] z = new double[accuracy, accuracy];

            for (int i = 0; i < accuracy; i++)
            {
                for (int j = 0; j < accuracy; j++)
                {
                    x[i, j] = radius * Math.Sin(phi[i]) * Math.Cos(theta[j]);
                    y[i, j] = radius * Math.Sin(phi[i]) * Math.Sin(theta[j]);
                    z[i, j] = radius * Math.Cos(phi[i]);
                    
                    listVertices.Add(new Vector3((float)x[i, j], (float)y[i, j], (float)z[i, j]));

                }
            }
            
            for (int i = 0; i < accuracy - 1; i++)
            {
                for (int j = 0; j < accuracy - 1; j++)
                {
                    int currentIndex = i * accuracy + j;
                    int nextIndex = currentIndex + accuracy;
                    listTriangles.Add(currentIndex);
                    listTriangles.Add(currentIndex + 1);
                    listTriangles.Add(nextIndex);

                    listTriangles.Add(nextIndex);
                    listTriangles.Add(currentIndex + 1);
                    listTriangles.Add(nextIndex + 1);
                }
            }
            
            
            
            mesh.vertices = listVertices.ToArray();
            mesh.triangles = listTriangles.ToArray();

        }
        
        public static float[] linspace(float startval, float endval, int steps)
        {
            
            float interval = (endval / MathF.Abs(endval)) * MathF.Abs(endval - startval) / (steps - 1);
            return (from val in Enumerable.Range(0,steps)
                select startval + (val * interval)).ToArray(); 
        }
}
