using System;
using System.Collections.Generic;
using System.Linq;
//using Unity.Mathematics;
using UnityEngine;
//using Random = Unity.Mathematics.Random;


    public class CircleGeneratorComponent:MonoBehaviour
    {

        public int acuracy = 10;
        public float radius = 1f;
        private Mesh mesh;
        private void Awake()
        {
            
            circle();


        }

        public void circle()
        {
            int accuracy = acuracy + 1;
            Mesh mesh = GetComponent<MeshFilter>().mesh;
            /*
            MeshFilter meshFilter = gameObject.AddComponent<MeshFilter>();
            MeshRenderer meshRenderer = gameObject.AddComponent<MeshRenderer>();*/


            /*Mesh mesh = new Mesh();
            Vector3 ind1 = new Vector3(0, 1, 0);
            Vector3 ind2 = new Vector3(1, 0, 0);
            Vector3 ind3 = new Vector3(0, 0, 0);

            mesh.vertices = new[] { ind1, ind2, ind3 };
            mesh.triangles = new int[] { 0, 1, 2 };
            meshFilter.sharedMesh = mesh;*/



            /*mesh.vertices = new[] { ind1, ind2, ind3 };*/
            /*mesh.triangles = new int[] { 0, 1, 2 };
            meshFilter.sharedMesh = mesh;*/


            Vector2[] uvTemplate = new Vector2[]
            {
                new Vector2 (0, 0),
                new Vector2 (1, 0),
                new Vector2 (0, 1),
                new Vector2 (1, 1)
            };
            int uvTemplateIndex = 0;

            mesh.Clear();
            List<Vector3> listVertices = new List<Vector3>();
            List<int> listTriangles = new List<int>();
            List<Vector2> uv = new List<Vector2>();

            var x = linspace(-radius, radius, accuracy);
            List<float> y = new List<float>();
            y.Add(0);
            listVertices.Add(new Vector3(0, 0, 0));
            
            uv.Add(uvTemplate[uvTemplateIndex%4]);
            uvTemplateIndex++;

            listVertices.Add(new Vector3(-radius, 0, 0));

            uv.Add(uvTemplate[uvTemplateIndex%4]);
            uvTemplateIndex++;
        
            var ind1 = 1;
            var ind2 = 1;

            

            int indV1 = 0;
            for(int i = 1; i < x.Length; i++)
            {
                y.Add((float)(Math.Sqrt(Math.Pow(radius, 2) - Math.Pow(x[i], 2))));
                // Debug.Log($"{x[i]} {y[i]}");
                listVertices.Add(new Vector3(x[i], y[i], 0));

                uv.Add(uvTemplate[uvTemplateIndex % 4]);
                uvTemplateIndex++;
            
                indV1 = listVertices.Count - 1;
                listTriangles.AddRange(new List<int> { 0, ind1, indV1 });
                ind1 = indV1;
                
            }
            
            int indV2;
            ind2 = indV1;
            for (int i = x.Length - 2; i > -1; i--)
            {
                // Debug.Log($"{x[i]} {-y[i]}");
                listVertices.Add(new Vector3(x[i], -y[i], 0));
                uv.Add(uvTemplate[uvTemplateIndex % 4]);
                uvTemplateIndex++;
                indV2 = listVertices.Count - 1;
                listTriangles.Add(0);
                listTriangles.Add(ind2);
                listTriangles.Add(indV2);
                ind2 = indV2;
            }

           /* foreach (var VARIABLE in listTriangles)
            {
                Debug.Log(VARIABLE);
            }*/
            
            mesh.vertices = listVertices.ToArray();
            mesh.triangles = listTriangles.ToArray();
            mesh.uv = uv.ToArray();
            
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
