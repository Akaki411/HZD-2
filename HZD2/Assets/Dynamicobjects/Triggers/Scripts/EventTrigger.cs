using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventTrigger : MonoBehaviour
{
    [SerializeField] private string layer;
    [SerializeField] private UnityEvent _event;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag(layer))
        {
 			_event.Invoke();
        }
    } 
}
