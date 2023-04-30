using UnityEngine;

[RequireComponent(typeof(PlayerInput))]
[RequireComponent(typeof(PlayerAnimator))]
[RequireComponent(typeof(Health))]

public class PlayerController : MonoBehaviour
{
    public static PlayerController S;

    public bool IsAlive = true;
    [SerializeField] private GameObject _weapon1;
    [SerializeField] private float _moveSpeed = 1;
    [SerializeField] private float _maxMoveSpeed = 10;

    private int _currentWeaponIndex = 0;

    private PlayerAnimator _playerAnimator;
    private Rigidbody2D _rb;
    private Health _health;

    //параметры для атаки

    protected float _currentCollDawn;
    private bool _canMove = true;


    void Awake()
    {
        if (S == null)
            S = this;

        _rb = GetComponent<Rigidbody2D>();
        _playerAnimator = GetComponent<PlayerAnimator>();
        _health = GetComponent<Health>();
    }

    public void Move(Vector2 direction)
    {
        if (IsAlive)
        {
            if (_canMove)
            {
                if (_rb.velocity.magnitude < _maxMoveSpeed)
                    _rb.AddForce(direction * _moveSpeed);
                _playerAnimator.Move(direction);
            }
        }
    }

    public void RotateWeapon(Vector3 direction)
    {
        _weapon1.transform.rotation = Quaternion.Euler(direction);
    }

    private void FixedUpdate()
    {
        if (_currentCollDawn > 0)
            _currentCollDawn -= 0.02f;        
    }

    public virtual void Attack()
    {
        if (IsAlive && _currentCollDawn <= 0)
        {

        }
    }

    public void SetWeapon(int weaponIndex)
    {
        if (_currentCollDawn <= 0)
        {
            
        }
    }

    public void SetNextWeapon()
    {
        if (_currentCollDawn <= 0)
        {

        }
    }

    public void SetPreviousWeapon()
    {
        if (_currentCollDawn <= 0)
        {

        }
    }

    public void Death()
    {
        IsAlive = false;
        PlayerInput.S.CanMove = false;
    }
}
