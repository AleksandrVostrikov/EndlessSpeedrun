using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoxController : MonoBehaviour
{
    [SerializeField] private Transform _player;

    private void LateUpdate()
    {
        transform.position = _player.position;
    }
}
