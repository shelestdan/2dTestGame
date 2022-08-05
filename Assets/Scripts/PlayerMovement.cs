using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(BoxCollider2D))]

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speedPlayer;
    private Rigidbody2D _playerRb;
    private Vector2 _playerMove;
    private float jumpForce = 5000f;
    public bool onGround = true;
    public Transform GroundCheck;
    public float checkRadius = 0.5f;
    public LayerMask Ground;


    private void Awake()
    {
        speedPlayer *= Time.deltaTime;
        _playerRb = GetComponent<Rigidbody2D>();
        _playerRb.constraints = RigidbodyConstraints2D.FreezeRotation;
        _playerRb.isKinematic = false;
    }

    private void FixedUpdate()
    {
        _playerRb.velocity = _playerMove * speedPlayer;
    }

    private void Update()
    {
        _playerMove.x = Input.GetAxis("Horizontal");
        if (Input.GetKeyDown(KeyCode.Space) && onGround)
        {
            _playerRb.AddForce(Vector2.up * jumpForce, ForceMode2D.Force);
        }
        CheckingGround();
    }


    public void CheckingGround()
    {
        onGround = Physics2D.OverlapCircle(GroundCheck.position, checkRadius, Ground);
    }
}
