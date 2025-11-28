using UnityEngine;

public class CarController : MonoBehaviour
{
    private PlayerControlers inputActions;
    private Vector2 moveInput;

    [Header("Car Settings")]
    public float moveSpeed = 10f;
    public float rotationSpeed = 100f;

    private void Awake()
    {
        // Instancia de la clase generada por el Input System
        inputActions = new PlayerControlers();
    }

    private void OnEnable()
    {
        
        inputActions.Car.Enable();

        inputActions.Car.Movement.performed += ctx => moveInput = ctx.ReadValue<Vector2>();
        inputActions.Car.Movement.canceled += ctx => moveInput = Vector2.zero;
    }

    private void OnDisable()
    {
        inputActions.Car.Disable();
    }

    private void Update()
    {
        // Movimiento hacia adelante y atrás con el eje Y
        float moveAmount = moveInput.y * moveSpeed * Time.deltaTime;
        transform.Translate(Vector3.forward * moveAmount);

        // Rotación con el eje X
        float rotationAmount = moveInput.x * rotationSpeed * Time.deltaTime;
        transform.Rotate(Vector3.up * rotationAmount);
    }
}
