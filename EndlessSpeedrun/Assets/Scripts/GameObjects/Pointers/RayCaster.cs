using UnityEngine;

public class RayCaster
{
    private RaycastHit _hit;

    public float[] GetGroundDistance(LayerMask layerMask, Transform[] _pointers)
    {
        float[] hitDistance = new float[_pointers.Length]; 
        for(int i = 0; i < _pointers.Length; i++)
        {
            if (_pointers[i].gameObject.activeSelf)
            {
                Vector3 midPosition = new Vector3(_pointers[i].position.x, 10, _pointers[i].position.z);
                Physics.Raycast(midPosition, Vector3.down, out _hit, Mathf.Infinity, layerMask, QueryTriggerInteraction.Ignore);
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
