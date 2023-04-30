using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform Target;
    private Vector3 _pos;

    void LateUpdate()
    {
        _pos = new Vector3(Target.position.x, Target.position.y, -1);
        transform.position = Vector3.MoveTowards(transform.position, _pos, 0.5f);
    }
}
