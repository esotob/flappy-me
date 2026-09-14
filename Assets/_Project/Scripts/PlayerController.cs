using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    [Header("Jump")]
    [SerializeField] private float jumpForce = 6f;

    [Header("Rotation")]
    [SerializeField] private float rotationFactor = 6f;
    [SerializeField] private float maxUpAngle = 30f;
    [SerializeField] private float maxDownAngle = -90f;

    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (JumpPressed())
        {
            Jump();
        }
    }

    private void FixedUpdate()
    {
        RotateByVelocity();
    }

    private bool JumpPressed()
    {
        bool keyboard = Keyboard.current != null && Keyboard.current.spaceKey.wasPressedThisFrame;
        bool mouse = Mouse.current != null && Mouse.current.leftButton.wasPressedThisFrame;
        bool touch = Touchscreen.current != null && Touchscreen.current.primaryTouch.press.wasPressedThisFrame;

        return keyboard || mouse || touch;
    }

    private void Jump()
    {
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
    }

    private void RotateByVelocity()
    {
        float angle = Mathf.Clamp(rb.linearVelocity.y * rotationFactor, maxDownAngle, maxUpAngle);
        rb.MoveRotation(angle);
    }
}