using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantField : MonoBehaviour
{
    private Vector2Int _gridSize = new Vector2Int(17, 52);

    private Vector2Int _elementalSize = new Vector2Int(3, 7);

    //private PlantsSize[,] _grid;
    private bool[,] _gridMap;
        
    private void Awake()
    {
        //_grid = new PlantsSize[_gridSize.x, _gridSize.y];
        _gridMap = new bool[_gridSize.x, _gridSize.y];
    }

    private void MakeGridMap(int placeX, int placeY, PlantsSize plant)
    {
        
        
        
        for (int x = 0; x < plant.Size.x; x++)
        {
            for (int y = 0; y < plant.Size.y; y++)
            {
                _gridMap[placeX + x, placeY + y] = true;
            }
        }
    }


}
