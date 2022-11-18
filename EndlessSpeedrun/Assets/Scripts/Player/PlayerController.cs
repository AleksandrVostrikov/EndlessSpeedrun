using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using static UnityEditor.Experimental.GraphView.GraphView;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Transform[] _linePositions;
    [SerializeField] private Transform _player;

    private CharacterController _characterController;
    private Vector3 _moveDirection;
    private int _lineIndex;

    public delegate void IndexChanged();
    public event IndexChanged OnIndexChanged;

    public int LineIndex { get { return _lineIndex; } }

    private void Start()
    {
        Initialize();
    }
    private void Update()
    {
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
                ChangePosition(_lineIndex);
                OnIndexChanged?.Invoke();
            }
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (_lineIndex > 0)
            {
                _lineIndex--;
                ChangePosition(_lineIndex);
                OnIndexChanged?.Invoke();
            }
        }
    }

    private void ChangePosition(int lineIndex)
    {
        Vector3 targetPosition = new Vector3(_linePositions[lineIndex].position.x, transform.position.y, transform.position.z);
        _player.transform.rotation = Quaternion.Euler(0, 90, 0);
        _player.transform.position = Vector3.Lerp(_player.transform.position, targetPosition, 10 * Time.deltaTime);
    }

    private void Initialize()
    {
        _characterController = GetComponent<CharacterController>();
        _lineIndex = 1;
        OnIndexChanged?.Invoke();
    }

    private void Move()
    {
        _moveDirection.z = _speed;
        _characterController.Move(_moveDirection * Time.fixedDeltaTime);
        ChangePosition(_lineIndex);
    }

}
