using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving : MonoBehaviour
{
    [SerializeField] Rigidbody2D _rigidbody;

    [Header("Бег / Ходьба")]
    [SerializeField] float _speed = 1;

    [Header("Прыжок")]
    [SerializeField] float _jumpForce = 1;

    
    private Vector2 _normal;
    private Vector2 directoinAlongSurface;
    private Vector2 offset;

    private float x = 0;



    private void Update()
    {
        x = Input.GetAxis("Horizontal");

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W))
        {
            this.Jump();
        }
        
        this.Move();
    }

    private void Move()
    {
        _rigidbody.velocity = new Vector2(x * _speed, _rigidbody.velocity.y);
    }

    private void Jump()
    {
        _rigidbody.AddForce(new Vector2(0, _jumpForce), ForceMode2D.Impulse);
    }

    private void FlipLeft()
    {
        transform.rotation = new Quaternion(0, 1, 0, 0);
    }

    private void FlipRight()
    {
        transform.rotation = new Quaternion(0, 0, 0, 1);
    }
}
