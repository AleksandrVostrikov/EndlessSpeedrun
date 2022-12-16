using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GizmosLines : MonoBehaviour
{
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        Gizmos.DrawRay(new Vector3(0,1,0), Vector3.forward * 60);
        for (int i = 2; i <= 8; i+=2)
        {
            Gizmos.DrawRay(new Vector3(-i, 1, 0), Vector3.forward * 60);
            Gizmos.DrawRay(new Vector3(i, 1, 0), Vector3.forward * 60);
        }
        


    }
}
