using UnityEngine;
using Player;

namespace Pointers
{
public class LineController : MonoBehaviour
{
    [SerializeField] private PlayerController _playerController;
    [SerializeField] private Transform[] _pointers;
    [SerializeField] private Transform _lines;
    [SerializeField] private Transform _player;
    [SerializeField] private int _maxChangeDistanceIndex;
    [SerializeField] private LayerMask _layerMask;

    private PointerRayCaster _rayCaster;
    
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
        _rayCaster = new();
    }

    private void Update()
    {
        ChangeDistanceBetveenPointers();
        SetPointersPositions();
    }

    private void LateUpdate()
    {
        _lines.position = new Vector3(transform.position.x, _player.position.y, _player.position.z);
    }

    private void ChangeDistanceBetveenPointers()
    {
        
        if (Input.GetKeyDown(KeyCode.KeypadPlus) && _maxChangeDistanceIndex < 4)
        {
            _maxChangeDistanceIndex++;
            _pointers[0].transform.position += Vector3.left *2 ;
            _pointers[2].transform.position += Vector3.right * 2;
        }
        else if (Input.GetKeyDown(KeyCode.KeypadMinus) && _maxChangeDistanceIndex > 1)
        {
            _maxChangeDistanceIndex--;
            _pointers[0].transform.position += Vector3.right * 2;
            _pointers[2].transform.position += Vector3.left * 2;
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

    private void SetPointersPositions()
    {
        float[] hitDistance = _rayCaster.GetGroundDistance(_layerMask, _pointers);
        for (int i = 0; i < 3; i++)
        {
            if (_pointers[i].gameObject.activeSelf)
            {
                _pointers[i].position = new Vector3(_pointers[i].position.x, 10.5f - hitDistance[i], _pointers[i].position.z);
            }
        }
    }
}
}


