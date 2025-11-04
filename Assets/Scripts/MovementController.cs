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
    private bool canLeft = false;
    private bool canRight = true;
    private bool canUp = false;
    private bool canDown = false;


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

        float horizontalInput = Input.GetAxis("Horizontal") * speed;

        if (!canLeft)
        {
            horizontalInput = Mathf.Clamp(horizontalInput, 0f, int.MaxValue);
        } 
        else if (!canRight)
        {
            horizontalInput = Mathf.Clamp(horizontalInput, int.MinValue, 0);
        } 


        playerRb.velocity = new Vector2(horizontalInput, playerRb.velocity.y);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded && canUp)
        {
            playerRb.velocity = new Vector2(playerRb.velocity.x, jumpForce);
        }
    }

    public void UnlockMovement(string direction)
    {
        switch (direction)
        {
            case "up":
                canUp = true;
                break;
            case "down":
                canDown = true;
                break;
            case "left":
                canLeft = true;
                break;
            case "right":
                canRight = true;
                break;
            default:
                break;
        }
    }
}
