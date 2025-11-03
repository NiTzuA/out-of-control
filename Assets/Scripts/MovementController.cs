using UnityEngine;

public class MovementController : MonoBehaviour
{
    private Rigidbody2D playerRb;
    private BoxCollider2D playerCol;

    [Header("Movement")]
    public float speed = 10f;
    public float jumpForce = 5f;

    [Header("Layers")]
    public LayerMask groundLayer;

    private bool isGrounded;


    private void Awake()
    {
        playerRb = GetComponent<Rigidbody2D>();
        playerCol = GetComponent<BoxCollider2D>();
    }

    void Start()
    {
        
    }

    private void Update()
    {
        RaycastHit2D hit = Physics2D.BoxCast(playerCol.bounds.center, playerCol.bounds.size, 0f, 
            Vector2.down, 0.05f, groundLayer);
        isGrounded = hit.collider != null;

        if (isGrounded)
        {
            Debug.Log("Me grounded BOI!");
        } else
        {
            Debug.Log("Me airborne BOI!");
        }

        float horizontalInput = Input.GetAxis("Horizontal") * speed;

        playerRb.velocity = new Vector2(horizontalInput, playerRb.velocity.y);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            playerRb.velocity = new Vector2(playerRb.velocity.x, jumpForce);
        }
    }
}
