using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private float _smoothSpeed = 0.125f;
    [SerializeField] private Vector3 _offset;

    //Borders
    [SerializeField] private Vector2 _minimum;
    [SerializeField] private Vector2 _maximum;

    private Transform _target;

    private void Start()
    {
        _target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void FixedUpdate()
    {
        if(true)
        {
            Vector3 _desiredPosition = _target.position + _offset;
            Vector3 _smoothedPosition = Vector3.Lerp(transform.position, _desiredPosition, _smoothSpeed);
            Vector3 _borderedPosition = new Vector3(Mathf.Clamp(_smoothedPosition.x, _minimum.x, _maximum.x), 
                                                    Mathf.Clamp(_smoothedPosition.y, _minimum.y, _maximum.y), 
                                                    _smoothedPosition.z);
            transform.position = _borderedPosition;
        }
    }
}
