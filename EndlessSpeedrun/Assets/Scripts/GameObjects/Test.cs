using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    Mesh mesh;
    Vector3[] vertices;

    private void Start()
    {
        mesh = GetComponent<MeshFilter>().mesh;
        vertices = mesh.vertices;
        foreach (Vector3 v in vertices)
        {
            Debug.Log(v.y);
        }

        
    }
}
