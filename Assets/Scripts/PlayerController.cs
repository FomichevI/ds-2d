using UnityEngine;

[RequireComponent(typeof(PlayerInput))]
[RequireComponent(typeof(PlayerAnimator))]
[RequireComponent(typeof(Health))]

public class PlayerController : MonoBehaviour
{
    public static PlayerController S;

    public bool IsAlive = true;
    [SerializeField] private GameObject _weapon1;
    [SerializeField] private MiliWeaponController _miliWeapon;

    //параметры передвижения
    [SerializeField] private float _moveSpeed = 1;
    [SerializeField] private float _maxMoveSpeed = 10;
    private RotationDirections _currentRotation = RotationDirections.dawn;
    public Vector2 MoveDirection;

    private int _currentWeaponIndex = 0;

    private PlayerAnimator _playerAnimator;
    private Rigidbody2D _rb;
    private Health _health;

    //параметры для атаки

    protected float _currentCollDawn;
    public bool CanMove = true;
    private bool _canAttack = true;


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
            if (CanMove)
            {
                //проверяем на движение спиной вперед
                if ((direction.x >= 0.5 && _currentRotation == RotationDirections.left) ||
                    (direction.x <= -0.5 && _currentRotation == RotationDirections.right) ||
                    (direction.y <= -0.5 && _currentRotation == RotationDirections.up) ||
                    (direction.x >= 0.5 && _currentRotation == RotationDirections.dawn))
                {
                    if (_rb.velocity.magnitude < _maxMoveSpeed/2)                    
                        _rb.AddForce(direction * _moveSpeed/2);                    
                }
                else if (_rb.velocity.magnitude < _maxMoveSpeed)
                {
                    _rb.AddForce(direction * _moveSpeed);
                }
            }
        }
    }

    public void RotateWeapon(Vector3 direction)
    {
        if (IsAlive)
        {
            if (CanMove)
            {
                //необходимо для определения направления удара при атаке
                if (direction != Vector3.zero)
                    MoveDirection =Vector3.Normalize(new Vector3(direction.x,direction.y,0));
                direction.x = direction.y = 0f;

                _weapon1.transform.rotation = Quaternion.Euler(direction);
                float z = direction.z;
                if (z <= -45 && z > -135)
                {
                    _currentRotation = RotationDirections.dawn;
                    _playerAnimator.ChangeDirection(RotationDirections.dawn);
                }
                else if (z <= 45 && z > -45)
                {
                    _currentRotation = RotationDirections.right;
                    _playerAnimator.ChangeDirection(RotationDirections.right);
                }
                else if (z <= 135 && z > 45)
                {
                    _currentRotation = RotationDirections.up;
                    _playerAnimator.ChangeDirection(RotationDirections.up);
                }
                else
                {
                    _currentRotation = RotationDirections.left;
                    _playerAnimator.ChangeDirection(RotationDirections.left);
                }
            }
        }
    }

    private void FixedUpdate()
    {

    }

    public virtual void Attack()
    {
        if (IsAlive && CanMove)
        {
            _miliWeapon.Attack();
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
