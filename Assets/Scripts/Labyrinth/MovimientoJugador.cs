using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class MovimientoJugador : MonoBehaviour
{
    public float velocidad = 5f;
    private Rigidbody2D rb;
    private Vector2 movimiento;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Captura entrada del teclado
        float moverX = Input.GetAxisRaw("Horizontal");
        float moverY = Input.GetAxisRaw("Vertical");
        movimiento = new Vector2(moverX, moverY).normalized;
    }

    void FixedUpdate()
    {
        // Aplica movimiento con física
        rb.linearVelocity = movimiento * velocidad;
    }
}