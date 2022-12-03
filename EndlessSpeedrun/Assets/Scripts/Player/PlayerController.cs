using UnityEngine;

namespace Player
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private float _speed;
        [SerializeField] private float _jumpHeight = 2f;
        [SerializeField] private float _gravity = -50f;

        [SerializeField] private Transform[] _linePositions;
        [SerializeField] private Transform _player;
        [SerializeField] private LayerMask _groundLayer;

        private bool _isGrounded;
        private Vector3 _velocity;

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
            CheckGrounded();
            RealizeGravity();
            Move();
            ChangePosition(_lineIndex);
            Jump();
            SwipeLine();
            SpeedUp();
            SpeedDown();
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
            transform.position = Vector3.Lerp(_player.transform.position, targetPosition, 30 * Time.deltaTime);
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
            _moveDirection.z = _speed;

            _characterController.Move(_velocity * Time.deltaTime);
            _characterController.Move(_moveDirection * Time.deltaTime);
        }

        private void CheckGrounded()
        {
            _isGrounded = Physics.CheckSphere(transform.position, 0.5f, _groundLayer, QueryTriggerInteraction.Ignore);
        }

        private void RealizeGravity()
        {
            if (_isGrounded && _velocity.y < 0)
            {
                _velocity.y = 0;
            }
            else
            {
                _velocity.y += _gravity * Time.deltaTime;
            }
        }

        private void Jump()
        {
            if (_isGrounded && Input.GetKeyDown(KeyCode.Space))
            {
                _velocity.y += Mathf.Sqrt(_jumpHeight * -2 * _gravity);
            }
        }

        private void SpeedUp()
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                _speed += 3;
            }
            else if (Input.GetKeyUp(KeyCode.UpArrow))
            {
                _speed -= 3;
            }
        }

        private void SpeedDown()
        {
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                _speed -= 3;
            }
            else if (Input.GetKeyUp(KeyCode.DownArrow))
            {
                _speed += 3;
            }
        }

    }
}
