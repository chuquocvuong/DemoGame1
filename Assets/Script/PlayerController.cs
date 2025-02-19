using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    public float moveSpeed = 5f;
    public float jumpForce = 15f;
    public LayerMask groundLayer;
    public Transform groundCheck;
    private bool isGrounded;
    private Animator animator;
    private Rigidbody2D rb;
    private GameManager gameManager;
    private AudioManager audioManager;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        gameManager = FindAnyObjectByType<GameManager>();
        audioManager = FindAnyObjectByType<AudioManager>();
    }
    void Start()
    {
      //  rb = GetComponent<Rigidbody2D>();   
       // animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.IsGameOver() || gameManager.IsGameWin()) return; 
        HandleMovement();
        HandleJump();
        UpdateAnimation();
    }
    private void HandleMovement()
    {
        float moveInput = Input.GetAxis("Horizontal");       
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);
        if(moveInput >0) transform.localScale = new Vector3(1,1,1);
        else if(moveInput < 0) transform.localScale = new Vector3(-1,1,1);
    }
    private void HandleJump()
    {

        // Cập nhật isGrounded trước khi kiểm tra nhảy
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.5f, groundLayer);
 //       Debug.Log("GroundCheck Position: " + groundCheck.position);
 //       Debug.Log("Is Grounded: " + isGrounded);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            audioManager.playJump();
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }
    private void UpdateAnimation()
    {
        bool isRunning = Mathf.Abs(rb.velocity.x) > 0.1f;
        bool isJumping = !isGrounded;
        animator.SetBool("isRunning", isRunning);
        animator.SetBool("isJumping", isJumping);
    }

}
