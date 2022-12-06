using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoxController : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private Transform _chiken;
    [SerializeField] private Transform _fox;

    [SerializeField] private float _speed;

    private void LateUpdate()
    {
        transform.position = _player.position;
        _fox.rotation = _chiken.rotation;
    }

    private void FixedUpdate()
    {
        //if (_fox.position.z < -1.66f)
        //{
        //    _fox.Translate(Vector3.forward * _speed * Time.fixedDeltaTime);
        //}

        _fox.position = Vector3.MoveTowards(_fox.position, _chiken.position, _speed * Time.fixedDeltaTime);
        
    }


}
