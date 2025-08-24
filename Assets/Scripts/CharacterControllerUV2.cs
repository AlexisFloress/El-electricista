using NUnit.Framework.Constraints;
using UnityEngine;

public class CharacterControllerUV2 : MonoBehaviour
{
    private CharacterController _characterController;
    private Vector3 _currentMovement;
    private Vector2 _movement;
    private float _sprint;
    private float _jumpForce;
    [SerializeField] private float _speed = 5f;
    private Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        _characterController = GetComponent<CharacterController>();
    }

    private void OnEnable()
    {
        
    }

    void Update()
    {
        _movement = InputManager.Instance.MoveInput;
        Debug.Log(_movement);
        MovePlayer();
        ApplyGravity();
       
    }
    void MovePlayer()
    {
        Vector3 newPosition = new Vector3(_movement.x, 0f, _movement.y).normalized;
        Vector3 worldDirection = transform.TransformDirection(newPosition);

        _currentMovement.z = worldDirection.z;
        _currentMovement.x = worldDirection.x;

        _characterController.Move(_currentMovement * _speed * Time.deltaTime);
    }


    void ApplyGravity()
    {
        if (!_characterController.isGrounded)
        {
            _currentMovement.y -= 9.81f * Time.deltaTime;
        }
    }
    void Jump()
    {
       
    }


}
