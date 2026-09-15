using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Pipe : MonoBehaviour
{
    [SerializeField] private float speed = 3f;
    [SerializeField] private float destroyX = -12f;

    private void Start()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.linearVelocity = Vector2.left * speed;
    }

    private void Update()
    {
        if (transform.position.x < destroyX)
        {
            Destroy(gameObject);
        }
    }
}