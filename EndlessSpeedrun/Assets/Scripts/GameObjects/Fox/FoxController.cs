using Player;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FoxController : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private Transform _chiken;
    [SerializeField] private Transform _fox;

    [SerializeField] private float _speed;

    private bool _moveFox;

    public bool MoveFox
    {
        get { return _moveFox; }
        set { _moveFox = value; }
    }

    private void LateUpdate()
    {
        transform.position = _player.position;
        _fox.rotation = _chiken.rotation;
    }

    private void FixedUpdate()
    {
        if (_moveFox)
        {
            _fox.position = Vector3.MoveTowards(_fox.position, _chiken.position, _speed * Time.fixedDeltaTime);
        }
    }
}
