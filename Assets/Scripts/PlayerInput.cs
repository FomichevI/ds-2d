using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public static PlayerInput S;

    //����������� ����������� �������� ������
    private float _horizontalMove;
    private float _verticalMove;
    private Vector2 _movement;

    //����������� ������� ����
    private Vector2 _ray;
    private Vector2 _directionHit;
    private Vector2 _lookPos;
    public bool CanMove = true; //��� ���������� ����������� �������������� � ������ �����

    private float _zoom;

    void Start()
    {
        if (S == null)
            S = this;
    }


    private void FixedUpdate()
    {
        //����������� ���������
        _horizontalMove = Input.GetAxis("Horizontal");
        _verticalMove = Input.GetAxis("Vertical");
        _movement = new Vector2(_horizontalMove, _verticalMove);
        PlayerController.S.Move(_movement);

        //������� ������ � ������� ������� ����
        if (CanMove)
        {
            Vector2 diference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            float rotateZ = Mathf.Atan2(diference.y, diference.x) * Mathf.Rad2Deg;            
            PlayerController.S.RotateWeapon(new Vector3(diference.x, diference.y, rotateZ));
        }
    }

    private void Update()
    {
        //�����
        if (Input.GetMouseButton(0))
            PlayerController.S.Attack();

        //����� ������
        if (Input.GetKeyDown(KeyCode.Alpha1))
            PlayerController.S.SetWeapon(0);
        if (Input.GetKeyDown(KeyCode.Alpha2))
            PlayerController.S.SetWeapon(1);
        if (Input.GetKeyDown(KeyCode.Alpha3))
            PlayerController.S.SetWeapon(2);

        //_zoom = Input.GetAxis("Mouse ScrollWheel");
        //if (_zoom != 0)
        //{
        //    if (_zoom < 0)
        //        PlayerController.S.SetPreviousWeapon();
        //    else
        //        PlayerController.S.SetNextWeapon();
        //}
    }
}
