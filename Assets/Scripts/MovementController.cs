using UnityEngine;
using System.Linq;
using System.Collections;

public class MovementController : MonoBehaviour
{
    private Rigidbody2D playerRb;
    private BoxCollider2D playerCol;
    private KeyCode[] jumpKeys = { KeyCode.UpArrow, KeyCode.W, KeyCode.Space };
    private KeyCode[] crouchKeys = { KeyCode.DownArrow, KeyCode.S, KeyCode.LeftControl };

    [Header("Movement")]
    public float speed = 10f;
    public float jumpForce = 5f;

    [Header("Layers")]
    public LayerMask groundLayer;
    public LayerMask platformLayer;

    private bool isGrounded;
    private bool canLeft = false;
    private bool canRight = true;
    private bool canUp = false;
    private bool canDown = false;

    private LayerMask jumpableLayers;


    private void Awake()
    {
        playerRb = GetComponent<Rigidbody2D>();
        playerCol = GetComponent<BoxCollider2D>();
        jumpableLayers = groundLayer | platformLayer;
    }

    private void Update()
    {
        RaycastHit2D hit = Physics2D.BoxCast(playerCol.bounds.center, playerCol.bounds.size, 0f, 
            Vector2.down, 0.05f, jumpableLayers);
        isGrounded = hit.collider != null;

        float horizontalInput = Input.GetAxis("Horizontal") * speed;

        if (!canLeft)
        {
            horizontalInput = Mathf.Clamp(horizontalInput, 0f, int.MaxValue);
        } 
        
        if (!canRight)
        {
            horizontalInput = Mathf.Clamp(horizontalInput, int.MinValue, 0);
        }

        playerRb.velocity = new Vector2(horizontalInput, playerRb.velocity.y);

        if (jumpKeys.Any(Input.GetKeyDown) && isGrounded && canUp)
        {
            playerRb.velocity = new Vector2(playerRb.velocity.x, jumpForce);
        }

        if (crouchKeys.Any(Input.GetKeyDown) && isGrounded && canDown)
        {
            StartCoroutine(CrouchThroughPlatform());
        } 
    }

    private IEnumerator CrouchThroughPlatform()
    {
        Collider2D[] platforms = Physics2D.OverlapCircleAll(transform.position, 1f, LayerMask.GetMask("platformLayer"));

        foreach (var platform in platforms)
        {
            Physics2D.IgnoreCollision(playerCol, platform, true);
        }

        yield return new WaitForSeconds(0.3f);

        foreach (var platform in platforms)
        {
            Physics2D.IgnoreCollision(playerCol, platform, false);
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

    public void LockMovement(string direction)
    {
        switch (direction)
        {
            case "up":
                canUp = false;
                break;
            case "down":
                canDown = false;
                break;
            case "left":
                canLeft = false;
                break;
            case "right":
                canRight = false;
                break;
            default:
                break;
        }
    }
}
