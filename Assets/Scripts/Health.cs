using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int _maxHp;
    private int _currentHp;
    //параметры для имуна к урону после удара
    private float immunityAfterHit = 1f;
    private bool isImmunity = false;

    private void Start()
    {
        _currentHp = _maxHp*1;
    }

    public void GetDamage(int damage)
    {
        _currentHp -= damage;
    }



}
