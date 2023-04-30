using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void Move(Vector2 direction)
    {
        _animator.SetFloat("DirectX", direction.x);
        _animator.SetFloat("DirectY", direction.y);

    }
}
