using UnityEngine;

namespace Player
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private CharacterController _characterController;
        [SerializeField] private Transform _groundCheck;
        [SerializeField] private LayerMask _groundMask;
        [SerializeField] private float _speed = 10f;
        [SerializeField] private float _gravity = -9.8f;
        [SerializeField] private float _groundDistance = 0.4f;
        [SerializeField] private float _jumpHeight = 3f;

        private Vector3 _velocity;
        private bool _isGrounded;

        private void Update()
        {
            CheckedGround();

            Jump();
            SitDown();
            Moved();
            Gravity();
        }

        private void SitDown()
        {
            if (Input.GetKey(KeyCode.LeftControl))
            {
                _characterController.height = 1f;
            }
            else
            {
                _characterController.height = 2f;
            }
        }

        private void Jump()
        {
            if (Input.GetButtonDown("Jump") && _isGrounded)
            {
                _velocity.y = Mathf.Sqrt(_jumpHeight * -2f * _gravity);
            }
        }

        private void CheckedGround()
        {
            _isGrounded = Physics.CheckSphere(_groundCheck.position, _groundDistance, _groundMask);
            if (_isGrounded && _velocity.y < 0)
            {
                _velocity.y = -2f;
            }
        }

        private void Gravity()
        {
            _velocity.y += _gravity * Time.deltaTime;
            _characterController.Move(_velocity * Time.deltaTime);
        }

        private void Moved()
        {
            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");

            Vector3 move = transform.right * x + transform.forward * z;
            _characterController.Move(move * _speed * Time.deltaTime);
        }
    }
}