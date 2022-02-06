using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StairPlatform : MonoBehaviour
{
    [SerializeField] private GameObject _arrow;
    [SerializeField] private BoxCollider2D _collider;
    [SerializeField] private float _arrowShowHideSpeed;

    private SpriteRenderer _arrowRenderer;
    private bool _hide;

    private void Start()
    {
        _arrowRenderer = _arrow.GetComponent<SpriteRenderer>();
    }

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

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Player") && _collider.enabled)
        {
            StartCoroutine(ShowArrow());
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            StartCoroutine(HideArrow());
        }
    }

    private IEnumerator Enable()
    {
        StartCoroutine(HideArrow());
        yield return new WaitForSeconds(0.4f);
        _collider.enabled = true;
    }

    private IEnumerator ShowArrow()
    {
        Color c;
        for (float i = _arrowRenderer.color.a; i < 0.6f; i += _arrowShowHideSpeed * Time.deltaTime)
        {
            c = _arrowRenderer.color;
            c.a = i;
            _arrowRenderer.color = c;
            if(_hide) break;
            yield return null;
        }
        if(!_hide)
        {
            c = _arrowRenderer.color;
            c.a = 0.6f;
            _arrowRenderer.color = c;
        }
    }

    private IEnumerator HideArrow()
    {
        Color c;
        _hide = true;
        for (float i = _arrowRenderer.color.a; i > 0; i -= _arrowShowHideSpeed * Time.deltaTime)
        {
            c = _arrowRenderer.color;
            c.a = i;
            _arrowRenderer.color = c;
            yield return null;
        }

        c = _arrowRenderer.color;
        c.a = 0;
        _arrowRenderer.color = c;
        _hide = false;
    }
}
