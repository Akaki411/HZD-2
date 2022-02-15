using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxLayer : MonoBehaviour
{
    [SerializeField] private float _speed;
    private float _velocity;
    private void FixedUpdate()
    {
        _velocity = CameraMove.singleton.GetCameraVelocity();
        if(Mathf.Abs(_velocity) > 0.001)
        {
            transform.position = new Vector2(transform.position.x + _velocity * _speed, transform.position.y);
        }
    }
}
