using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class PlantsSize : MonoBehaviour
{
    [SerializeField] Vector2Int _size = Vector2Int.one;

    public Vector2Int Size { get { return _size; } }

    private void OnDrawGizmos()
    {
        for (int x = 0; x < _size.x; x++)
        {
            for (int y = 0; y < _size.y; y++)
            {
                if ((x + y) % 2 == 0)
                {
                    Gizmos.color = new Color(1, 0, 0, 0.5f);
                }
                else
                {
                    Gizmos.color = new Color(0, 1, 0, 0.5f);
                }
                Gizmos.DrawCube(transform.position + new Vector3(x,0,y), new Vector3(1, 0.2f, 1));
            }
        }
    }
}
