using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chunk : MonoBehaviour
{
    [SerializeField] private Transform _begin;
    [SerializeField] private Transform _end;

    public Transform Begin { get { return _begin; } }
    public Transform End { get { return _end; } }
}
