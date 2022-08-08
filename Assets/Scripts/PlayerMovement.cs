using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(BoxCollider2D))]

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speedPlayer;
    [SerializeField] private float jumpForce = 20f;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask ground;
    private bool _onGround = true;
    private Rigidbody2D _pRb;
    private float _moveInput;

    private void Awake()
    {
        _pRb = GetComponent<Rigidbody2D>();
        _pRb.constraints = RigidbodyConstraints2D.FreezeRotation;
    }

    private void FixedUpdate()
    {
        _moveInput = Input.GetAxis("Horizontal");
        _pRb.velocity = new Vector2(_moveInput * speedPlayer, _pRb.velocity.y);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _onGround)
        {
            _pRb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        }
        
        CheckingGround();
    }

    private void CheckingGround()
    {
        _onGround = Physics2D.OverlapBox(groundCheck.position, new Vector2(1.1f, 1.2f), 0, ground);
    }
}
