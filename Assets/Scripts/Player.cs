using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Animator))]

public class Player : MonoBehaviour
{
    private const string RunningAnimationBool = "IsRunning";
    private const string JumpingAnimationBool = "IsJumping";

    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;

    public event UnityAction<int> OnMoneyChanged;
    private SpriteRenderer _spriteRenderer;
    private Rigidbody2D _rigidBody2D;
    private Animator _animator;
    private bool _isGrounded;
    private int _money = 0;

    private void Start()
    {
        _rigidBody2D = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
        _isGrounded = true;
        OnMoneyChanged?.Invoke(_money);
    }

    private void Update()
    {
        print(_isGrounded);
        
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(_speed * Time.deltaTime, 0, 0);
            _spriteRenderer.flipX = false;
            _animator.SetBool(RunningAnimationBool, true);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(_speed * Time.deltaTime * -1, 0, 0);
            _spriteRenderer.flipX = true;
            _animator.SetBool(RunningAnimationBool, true);
        }
        else if (Input.GetKeyDown(KeyCode.Space) && _isGrounded)
        {
            _rigidBody2D.AddForce(Vector2.up * _jumpForce);
            _animator.SetBool(JumpingAnimationBool, true);
            _isGrounded = false;
        }
        else
        {
            _animator.SetBool(JumpingAnimationBool, false);
            _animator.SetBool(RunningAnimationBool, false);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.TryGetComponent(out Ground _))
        {
            _isGrounded = true;
        }
    }

    public void SubscribeMoney(Strawberry strawberry)
    {
        strawberry.OnCollected += AddMoney;
    }

    private void AddMoney(Strawberry strawberry)
    {
        _money++;
        strawberry.OnCollected -= AddMoney;
        OnMoneyChanged?.Invoke(_money);
    }
}
