using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(BoxCollider2D))]

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speedPlayer;
    private Rigidbody2D _pRb;
    private float jumpForce = 10f;
    public bool onGround = true;
    public Transform GroundCheck;
    public float checkRadius = 0.5f;
    public LayerMask Ground;
    private float moveInput;


    private void Awake()
    {
        _pRb = GetComponent<Rigidbody2D>();
        _pRb.constraints = RigidbodyConstraints2D.FreezeRotation;
        _pRb.isKinematic = false;
    }

    private void FixedUpdate()
    {
        moveInput = Input.GetAxis("Horizontal");
        _pRb.velocity = new Vector2(moveInput * speedPlayer, _pRb.velocity.y);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && onGround)
        {
            _pRb.velocity = Vector2.up * jumpForce;
        }
        
        CheckingGround();
    }


    public void CheckingGround()
    {
        onGround = Physics2D.OverlapCircle(GroundCheck.position, checkRadius, Ground);
    }
}
