using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using static UnityEditor.Experimental.GraphView.GraphView;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Transform[] _linePositions;
    [SerializeField] private Transform _player;

    private float gravity = -50f;
    private Vector3 _velocity;
    private float _jumpHeight = 200f;

    private CharacterController _characterController;
    private Vector3 _moveDirection;
    private int _lineIndex;

    public delegate void IndexChanged();
    public event IndexChanged OnIndexChanged;

    private string _rotatateDirection;

    public int LineIndex { get { return _lineIndex; } }

    private void Start()
    {
        Initialize();
    }
    private void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            _velocity.y += Mathf.Sqrt(_jumpHeight * -2 * gravity);
        }
        SwipeLine();
    }

    private void FixedUpdate()
    {
        Move();
    }
    
    private void SwipeLine()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (_lineIndex < 2)
            {
                _lineIndex++;
                _rotatateDirection = "Right";
                ChangePosition(_lineIndex);
                OnIndexChanged?.Invoke();
            }
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (_lineIndex > 0)
            {
                _lineIndex--;
                _rotatateDirection = "Left";
                ChangePosition(_lineIndex);
                OnIndexChanged?.Invoke();
            }
        }
    }

    private void ChangePosition(int lineIndex)
    {
        Vector3 targetPosition = new Vector3(_linePositions[lineIndex].position.x, transform.position.y, transform.position.z);
        SetRotation(lineIndex, _rotatateDirection);
        transform.position = Vector3.Lerp(_player.transform.position, targetPosition, 10 * Time.deltaTime);
    }

    private void SetRotation(int lineIndex, string direction)
    {
        if (Mathf.Abs(_linePositions[lineIndex].position.x - _player.transform.position.x) > 0.3f)
        {
            if (direction == "Right")
            {
                _player.transform.rotation = Quaternion.Lerp(_player.transform.rotation, Quaternion.Euler(0, 75, 0), 15 * Time.deltaTime);
            }
            else if (direction == "Left")
            {
                _player.transform.rotation = Quaternion.Lerp(_player.transform.rotation, Quaternion.Euler(0, -75, 0), 15 * Time.deltaTime);
            }
        }
        else
        {
            _player.transform.rotation = Quaternion.Lerp(_player.transform.rotation, Quaternion.Euler(0, 0, 0), 15 * Time.deltaTime);
        }
    }

    private void Initialize()
    {
        _characterController = GetComponent<CharacterController>();
        _lineIndex = 1;
        OnIndexChanged?.Invoke();
    }

    private void Move()
    {
        _velocity.y += gravity * Time.fixedDeltaTime;
        _moveDirection.z = _speed;
        _characterController.Move(_moveDirection * Time.fixedDeltaTime);
        _characterController.Move(_velocity * Time.fixedDeltaTime);
        ChangePosition(_lineIndex);
    }

}
