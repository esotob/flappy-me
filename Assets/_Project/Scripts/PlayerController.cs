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
    private float defaultGravity;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        defaultGravity = rb.gravityScale;
        rb.gravityScale = 0f;
    }

    private void Update()
    {
        if (GameManager.Instance.State == GameManager.GameState.GameOver)
        {
            return;
        }

        if (!JumpPressed())
        {
            return;
        }

        if (GameManager.Instance.State == GameManager.GameState.Ready)
        {
            GameManager.Instance.StartGame();
            rb.gravityScale = defaultGravity;
        }

        Jump();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameManager.Instance.GameOver();
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