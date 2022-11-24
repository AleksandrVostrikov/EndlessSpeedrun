using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using TMPro;
using Unity.Burst.CompilerServices;
using UnityEditorInternal;
using UnityEngine;

public class PointerPositionCalculator
{
    private Transform[] _pointerPosition;
    private LayerMask _layerMask;
    private RaycastHit _hit;

    public PointerPositionCalculator(Transform[] _pointers, LayerMask _layer)
    {
        _pointerPosition = new Transform[3];
        for (int i = 0; i < _pointers.Length; i++)
        {
            _pointerPosition[i].position = _pointers[i].position + Vector3.up * 6;
        }
        _layerMask = _layer;
    }

    public float[] GetPointersDistance()
    {
        Debug.DrawRay(_pointerPosition[0].position, _pointerPosition[0].TransformDirection(-Vector3.up), Color.red);
        float[] result = new float[3];
        for (int i = 0; i < 3; i++)
        {
            Physics.Raycast(_pointerPosition[i].position, _pointerPosition[i].TransformDirection(- Vector3.up), out _hit, Mathf.Infinity, _layerMask, QueryTriggerInteraction.Ignore);
            Debug.DrawRay(_pointerPosition[i].position, _pointerPosition[i].TransformDirection(-Vector3.up) * _hit.distance, Color.red);
            result[i] = _hit.distance;
        }
            
        Debug.Log(result);
        return result;
    }




}
