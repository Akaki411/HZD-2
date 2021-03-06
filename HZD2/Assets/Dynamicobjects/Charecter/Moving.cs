using UnityEngine;

public class Moving : MonoBehaviour
{
    [Header("Бег / Ходьба")]
    [SerializeField] private float _speed = 1;

    [SerializeField] private float _runFactor = 0.6f;

    [Header("Прыжок")]
    [SerializeField] private float _jumpForce = 1;
    [SerializeField] private Transform _footPosition;
    [SerializeField] private LayerMask _whatIsGround;
    [SerializeField] private float _groundDetectRadius;

    [Header("Прочее")]
    [SerializeField] private Rigidbody2D _rigidbody;
    
    private Vector2 _normal;
    private Vector2 directoinAlongSurface;
    private Vector2 offset;

    private Collider2D hit;

    private float x = 0;
    private bool _isGround;

    private void Start()
    {
        EventController.singleton.FlipRight += FlipRight;
        EventController.singleton.FlipLeft += FlipLeft;
        EventController.singleton.StartRun += StartRun;
        EventController.singleton.StopRun += StopRun;
    }

    private void Update()
    {
        x = Input.GetAxis("Horizontal");

        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W)) && _isGround)
        {
            this.Jump();
        }
        
        this.Move();

        hit = Physics2D.OverlapCircle(_footPosition.position, _groundDetectRadius, _whatIsGround);
        _isGround = hit;
    }

    private void Move()
    {
        _rigidbody.velocity = new Vector2(x * _speed * _runFactor, _rigidbody.velocity.y);
    }

    private void Jump()
    {
        _rigidbody.AddForce(new Vector2(0, _jumpForce), ForceMode2D.Impulse);
    }

    private void StartRun()
    {
        _runFactor = 1;
    }
    
    private void StopRun()
    {
        _runFactor = 0.6f;
    }

    private void FlipLeft()
    {
        transform.rotation = new Quaternion(0, 1, 0, 0);
    }

    private void FlipRight()
    {
        transform.rotation = new Quaternion(0, 0, 0, 1);
    }
}
