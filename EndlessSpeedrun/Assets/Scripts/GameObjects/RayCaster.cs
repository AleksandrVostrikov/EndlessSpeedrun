using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class RayCaster : MonoBehaviour
{
    [SerializeField] PlayerController _playerController;
    [SerializeField] GameObject[] _pointers;

    private RaycastHit _hit;

    public float[] GetGroundDistance(LayerMask layerMask)
    {
        float[] hitDistance = new float[_pointers.Length]; 
        for(int i = 0; i < _pointers.Length; i++)
        {
            if (_pointers[i].activeSelf)
            {
                Vector3 midPosition = Vector3.up * 6;
                Physics.Raycast(_pointers[i].transform.position, _pointers[i].transform.TransformDirection(Vector3.down) + midPosition, out _hit, Mathf.Infinity, layerMask, QueryTriggerInteraction.Ignore);
                //Debug.DrawRay(_pointers[i].transform.position, _pointers[i].transform.TransformDirection(Vector3.down) * _hit.distance, Color.red);
                hitDistance[i] = _hit.distance;
            }
            else
            {
                hitDistance[i] = 0;
            }
        }
        return hitDistance;
    }
}
