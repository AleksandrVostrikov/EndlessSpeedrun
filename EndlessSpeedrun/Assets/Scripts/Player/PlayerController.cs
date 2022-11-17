using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Transform[] _linePositions;

    private CharacterController _characterController;
    private Vector3 _moveDirection;
    public int _lineIndex;

    private void Start()
    {
        _characterController = GetComponent<CharacterController>();
        _lineIndex = 1;
    }

    private void FixedUpdate()
    {
        _moveDirection.z = _speed;
        _characterController.Move(_moveDirection * Time.fixedDeltaTime);
    }

    private void Update()
    {
        SwipeLine();
    }
    private void SwipeLine()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (_lineIndex < 2)
            {
                _lineIndex++;
                //transform.position = new Vector3(_linePositions[_lineIndex].position.x, transform.position.y, transform.position.z);
                _moveDirection.x = _linePositions[_lineIndex].position.x;
            }
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (_lineIndex > 0)
            {
                _lineIndex--;
                //transform.position = new Vector3(_linePositions[_lineIndex].position.x, transform.position.y, transform.position.z);
                _moveDirection.x = _linePositions[_lineIndex].position.x;
            }
        }
    }

}
