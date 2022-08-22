using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(BoxCollider2D))]

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speedPlayer;
    [SerializeField] private float jumpForce = 20f;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask ground;
    private SpriteRenderer _pSr;
    private Animator _playerAnimator;
    private bool _onGround = true;
    private Rigidbody2D _pRb;
    private float _moveInput;
    private static readonly int Run = Animator.StringToHash("Run");
    private static readonly int Jump = Animator.StringToHash("Jump");
    private static readonly int Down = Animator.StringToHash("Down");

    private void Awake()
    {
        _playerAnimator = GetComponent<Animator>();
        _pRb = GetComponent<Rigidbody2D>();
        _pRb.constraints = RigidbodyConstraints2D.FreezeRotation;
        _pSr = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        HandleAir();
        Flip();
        _moveInput = Input.GetAxis("Horizontal");
         _playerAnimator.SetBool(Run, Mathf.Abs(_moveInput) >= 0.1f);
        _pRb.velocity = new Vector2(_moveInput * speedPlayer, _pRb.velocity.y);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _onGround)
        {
            _playerAnimator.SetTrigger(Jump);
            _pRb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        }
        
        CheckingGround();
    }

    private void CheckingGround()
    {
        _onGround = Physics2D.OverlapBox(groundCheck.position, new Vector2(1.1f, 1.2f), 0, ground);
    }

    private void Flip()
    {
        _pSr.flipX = _moveInput < 0; 
    }

    private void HandleAir()
    {
        if(IsFalling())
        {
            _playerAnimator.SetBool(Down, false);
        }
    }

    private bool IsFalling()
    {
        if (_pRb.velocity.y < 0 && !_onGround)
        {
            return true;
        }

        return false;
    }
}
