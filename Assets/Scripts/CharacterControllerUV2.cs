using NUnit.Framework.Constraints;
using UnityEngine;

public class CharacterControllerUV2 : MonoBehaviour
{
    private CharacterController _characterController;
    private Vector3 _currentMovement;
    private Vector2 _movement;
    private float _sprint;
    private Animator _animator;
    [SerializeField] private float _speed = 5f;
    [SerializeField] private float _jumpForce = 5f;
    void Start()
    {
        _animator = GetComponent<Animator>();
        _characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        _movement = InputManager.Instance.MoveInput;
        Debug.Log(_movement);
        MovePlayer();
        ApplyGravity();
        JumpPlayer();
       
    }
    void MovePlayer()
    {
        Vector3 newPosition = new Vector3(_movement.x, 0f, _movement.y).normalized;
        Vector3 worldDirection = transform.TransformDirection(newPosition);

        _currentMovement.z = worldDirection.z;
        _currentMovement.x = worldDirection.x;

        _characterController.Move(_currentMovement * _speed * Time.deltaTime);

        Vector3 localVelocity = transform.InverseTransformDirection(_currentMovement);
        _animator.SetFloat("VelocityX", localVelocity.x);
        _animator.SetFloat("VelocityZ", localVelocity.z);

    }
    void JumpPlayer()
    {
        if(InputManager.Instance.JumpPressed && _characterController.isGrounded)
        {
            _currentMovement.y = _jumpForce;
            _animator.SetBool("Jump", true);
            InputManager.Instance.ResetJump();
        }
        if (_characterController.isGrounded && _currentMovement.y <= 0f)
        {
            _animator.SetBool("Jump", false);
            _currentMovement.y = 0f;
            
        }

    }


    void ApplyGravity()
    {
        if (!_characterController.isGrounded)
        {
            _currentMovement.y -= 9.81f * Time.deltaTime;
        }
    }
}
