using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stair : MonoBehaviour
{
    [SerializeField] private float speed = 1;
    private Rigidbody2D _character;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            _character = other.gameObject.GetComponent<Rigidbody2D>();
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if(Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.W))
        {
            if(other.gameObject.CompareTag("Player"))
            {
                _character.velocity = new Vector2(_character.velocity.x, speed);
            }
        }
    }
}
