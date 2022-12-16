using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantField : MonoBehaviour
{
    private Vector2Int _gridSize = new Vector2Int(17, 52);

    private PlantsSize[,] _grid;

    private void Awake()
    {
        _grid = new PlantsSize[_gridSize.x, _gridSize.y];
    }


}
