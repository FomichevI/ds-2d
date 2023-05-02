using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum RotationDirections { right, left, up, dawn }

public class PlayerAnimator : MonoBehaviour
{
    private Animator _animator;
    //параметры для определения, куда повернут персонаж
    private RotationDirections _rotation = RotationDirections.dawn;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    //public void Move(Vector2 direction)
    //{
    //    _animator.SetFloat("DirectX", direction.x);
    //    _animator.SetFloat("DirectY", direction.y);

    //}

    public void ChangeDirection(RotationDirections rotate)
    {
        _rotation = rotate;
        switch (rotate)
        {
            case (RotationDirections.up):
                _animator.SetInteger("Direction", 0);
                break;
            case (RotationDirections.right):
                _animator.SetInteger("Direction", 1);
                break;
            case (RotationDirections.dawn):
                _animator.SetInteger("Direction", 2);
                break;
            case (RotationDirections.left):
                _animator.SetInteger("Direction", 3);
                break;
        }
    }

}
