using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class LineController : MonoBehaviour
{
    [SerializeField] private PlayerController _playerController;
    [SerializeField] private Transform[] _pointers;
    [SerializeField] private Transform _lines;
    [SerializeField] private Transform _player;
    [SerializeField] private int _maxChangeDistanceIndex;
    [SerializeField] private LayerMask _layerMask;
    [SerializeField] private PointerPositionCalculator _pointerPositionCalculator;
    
    private void OnEnable()
    {
        _playerController.OnIndexChanged += IndexChanged;
    }
    private void OnDisable()
    {
        _playerController.OnIndexChanged -= IndexChanged;
    }

    private void Start()
    {
        _maxChangeDistanceIndex = 3;
        _pointerPositionCalculator = new(_pointers, _layerMask);
        GetPointerPosition();
    }

    private void Update()
    {
        ChangeDistanceBetveenPointers();
    }

    private void LateUpdate()
    {
        _lines.position = new Vector3(transform.position.x, _player.position.y, _player.position.z);
    }

    private float[] GetPointerPosition()
    {
        return _pointerPositionCalculator.GetPointersDistance();
    }

    private void ChangeDistanceBetveenPointers()
    {
        
        if (Input.GetKeyDown(KeyCode.KeypadPlus) && _maxChangeDistanceIndex < 5)
        {
            _maxChangeDistanceIndex++;
            _pointers[0].transform.position += Vector3.left;
            _pointers[2].transform.position += Vector3.right;
        }
        else if (Input.GetKeyDown(KeyCode.KeypadMinus) && _maxChangeDistanceIndex > 0)
        {
            _maxChangeDistanceIndex--;
            _pointers[0].transform.position += Vector3.right;
            _pointers[2].transform.position += Vector3.left;
        }
    }

    private void IndexChanged()
    {
        int LineIndex = _playerController.LineIndex;
        foreach (Transform go in _pointers)
        {
            go.gameObject.SetActive(true);
        }
        _pointers[LineIndex].gameObject.SetActive(false);

    }
}
