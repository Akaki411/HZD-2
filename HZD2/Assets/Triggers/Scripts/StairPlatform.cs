using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StairPlatform : MonoBehaviour
{
    [SerializeField] private BoxCollider2D _collider;

    private void OnCollisionStay2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            if(Input.GetKey(KeyCode.S))
            {
                if(_collider.enabled)
                {
                    _collider.enabled = false;
                    StartCoroutine(Enable());
                }
            }
        }
    }

    private IEnumerator Enable()
    {
        yield return new WaitForSeconds(0.2f);
        _collider.enabled = true;
    }
}
