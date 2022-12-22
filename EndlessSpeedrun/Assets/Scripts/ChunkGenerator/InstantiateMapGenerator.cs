using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System.Timers;
using UnityEngine;

public class InstantiateMapGenerator : MonoBehaviour
{
    private Vector2Int _elementalSize = new Vector2Int(3, 7);
    private bool[,] _gridMap = new bool[19, 49];
    
    private int GenerateOddNumber()
    {
        int num = Random.Range(1, 18);
        if (num % 2 != 0)
        {
            return num;
        }
        else
        {
            return num++;
        }
    }

    private void MakeGates()
    {
        for (int i = 0; i < 49; i += 7)
        {
            int gate = GenerateOddNumber();
            for (int j = gate-1; j <= gate + 1; j++)
            {
                for (int k = i; k < i + 8; k++)
                {
                    _gridMap[j, k] = true;
                }
            }
        }
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
