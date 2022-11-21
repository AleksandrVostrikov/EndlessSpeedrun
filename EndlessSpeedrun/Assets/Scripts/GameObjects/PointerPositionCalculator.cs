using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using TMPro;
using UnityEditorInternal;
using UnityEngine;

public class PointerPositionCalculator
{
    private Vector3[] _pointerPosition;
    private LayerMask _layerMask;
    private RaycastHit _hit;

    public PointerPositionCalculator(Transform[] _pointers, LayerMask _layer)
    {
        _pointerPosition = new Vector3[3];
        for (int i = 0; i < _pointers.Length; i++)
        {
            _pointerPosition[i] = _pointers[i].position + Vector3.up * 6;
        }
        _layerMask = _layer;
    }

    public float[] GetPosition()
    {
        float[] result = new float[3];
        for (int i = 0; i < 3; i++)
        {
            Physics.Raycast(_pointerPosition[i], -Vector3.up, out _hit, Mathf.Infinity, _layerMask, QueryTriggerInteraction.Ignore);
            result[i] = _hit.distance;
        }
            
        Debug.Log(result);
        return result;
    }




}
