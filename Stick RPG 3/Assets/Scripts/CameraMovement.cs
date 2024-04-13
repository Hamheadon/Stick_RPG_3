using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    Vector3 _offset;
    [SerializeField] Transform _targetTransform;
    [SerializeField] float _smoothTime;
    Vector3 _currentVelocity = Vector3.zero;

    private void Awake()
    {
        _offset = transform.position - _targetTransform.position;
    }

    private void LateUpdate()
    {
        Vector3 targetPosition = _targetTransform.position + _offset;
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref _currentVelocity, _smoothTime);
    }
}
