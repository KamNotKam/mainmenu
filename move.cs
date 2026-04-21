using UnityEngine;
using UnityEngine.InputSystem;

public class move : MonoBehaviour
{
    public float speed = 5f;
    private Rigidbody2D rb;
    private Vector2 movement;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        movement = Vector2.zero;

        if (Keyboard.current.wKey.isPressed)
            movement.y = 1;
        if (Keyboard.current.sKey.isPressed)
            movement.y = -1;
        if (Keyboard.current.aKey.isPressed)
            movement.x = -1;
        if (Keyboard.current.dKey.isPressed)
            movement.x = 1;

        movement = movement.normalized;

        // Rotasi arah gerak
        if (movement != Vector2.zero)
        {
            float angle = Mathf.Atan2(movement.y, movement.x) * Mathf.Rad2Deg;

            // 🔥 FIX DI SINI
            rb.rotation = angle + 90f;
        }
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
    }
}