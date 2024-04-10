using UnityEngine;


public class AutoMovePlayer : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float speedIncrement = 8f;
    public float minSpeed = 6f;
    public float maxSpeed = 25f;
    public float jumpForce = 700f; // Force applied upwards to perform a jump
    public Transform groundCheck; // A Transform positioned where you expect the ground to be relative to your player
    public float groundCheckRadius = 0.2f; // The radius of the ground check
    public LayerMask whatIsGround; // A LayerMask indicating what is considered ground

    private Rigidbody2D rb;
    private bool isGrounded; // Whether or not the player is currently touching the ground

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        moveSpeed = Mathf.Clamp(moveSpeed, minSpeed, maxSpeed);
    }

    private void Update()
    {
        // Ground check
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);

        // Speed adjustment
        if (Input.GetKey(KeyCode.A))
        {
            moveSpeed = Mathf.Max(minSpeed, moveSpeed - speedIncrement * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            moveSpeed = Mathf.Min(maxSpeed, moveSpeed + speedIncrement * Time.deltaTime);
        }

        // Jumping
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        }
    }

    private void FixedUpdate()
    {
        // Automatic movement to the right
        rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
    }

    private void OnDrawGizmosSelected()
    {
        // If you're using a ground check, this helps visualize it in the editor
        if (groundCheck == null) return;
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
    }
}