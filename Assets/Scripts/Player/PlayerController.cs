using UnityEngine;

public enum ControlType
{
    PC,
    Mobile
}

public class PlayerController : MonoBehaviour
{
    [SerializeField] private ControlType _controlType;
    [SerializeField] private GameObject _playerSprite; 
    [SerializeField] private float _moveSpeed = 5.0f;

    private Rigidbody2D _rb;
    private Animator _animator;


    public void AddSpeed(float _value)
    {
        _moveSpeed += _value;
    }

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _animator = _playerSprite.GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");

        Vector2 movement = new Vector2(horizontalInput, 0f);
        movement.Normalize();
        _rb.velocity = movement * _moveSpeed;

        if (horizontalInput < 0)
        {
            _playerSprite.transform.localScale = new Vector2(-1, 1); 
        }
        else if (horizontalInput > 0)
        {
            _playerSprite.transform.localScale = new Vector2(1, 1);
        }

        // if(horizontalInput > 0 || horizontalInput < 0 || verticalInput > 0 || verticalInput < 0)
        //     _animator.SetBool("IsMoving", true);
        // else
        //     _animator.SetBool("IsMoving", false);
    }
}
