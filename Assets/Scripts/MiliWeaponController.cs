using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiliWeaponController : MonoBehaviour
{
    [SerializeField] private GameObject _weaponRoot;
    private int _comboIndex = 0;
    [SerializeField] private float _timeToAnnulCombo = 1.5f;
    [SerializeField] private float _chargeForce = 10f;
    private float _currentTimeToAnnulCombo = 0;
    [SerializeField] private Animator _animator;
    private PlayerController _playerController;

    private void Start()
    {
        _playerController = PlayerController.S;
    }

    public void Attack()
    {
        if(_comboIndex == 0)
        {
            _animator.SetTrigger("Attack_1");
            _currentTimeToAnnulCombo = _timeToAnnulCombo;
            _comboIndex++;
        }
        else if(_comboIndex == 1)
        {
            _animator.SetTrigger("Attack_2");
            _currentTimeToAnnulCombo = _timeToAnnulCombo;
            _comboIndex++;
        }
        else if (_comboIndex == 2)
        {
            _animator.SetTrigger("Attack_3");
            ChargeFront();
            _currentTimeToAnnulCombo = 0;
        }
    }

    private void ChargeFront()
    {
        Debug.Log("чардж");
        Debug.Log(_playerController.MoveDirection);
        _playerController.gameObject.GetComponent<Rigidbody2D>().AddForce(_playerController.MoveDirection*_chargeForce*100);
    }

    private void FixedUpdate()
    {
        if (_currentTimeToAnnulCombo > 0)
            _currentTimeToAnnulCombo -= 0.02f;
        else
            _comboIndex = 0;
    }

    public void StopMoving()
    {
        _playerController.CanMove = false;
    }
    public void StartMoving()
    {
        _playerController.CanMove = true;
    }

}
