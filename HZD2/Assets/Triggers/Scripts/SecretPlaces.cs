using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class SecretPlaces : MonoBehaviour
{
    [SerializeField] private float _hideSpeed = 0.1f;
    [SerializeField] private Tilemap _tilemap;
    private bool _isShowing = false;
    private bool _isHidding = false;


    public void Show()
    {
        if(!_isShowing)
        {
            _isShowing = true;
            StartCoroutine(Showing());
        }
    }

    public void Hide()
    {
        if(!_isHidding)
        {
            _isHidding = true;
            StartCoroutine(Hidding());
        }
        
    }

    private IEnumerator Showing()
    {
        Color c;
        for (float ft = _tilemap.color.a; ft <= 1; ft += _hideSpeed) 
        {
            c = _tilemap.color;
            c.a = ft;
            _tilemap.color = c;
            yield return null;
        }

        c = _tilemap.color;
        c.a = 1;
        _tilemap.color = c;
        _isShowing = false;
    }
    
    private IEnumerator Hidding()
    {
        Color c;
        for (float ft = _tilemap.color.a; ft >= 0; ft -= _hideSpeed) 
        {
            c = _tilemap.color;
            c.a = ft;
            _tilemap.color = c;
            yield return null;
        }

        c = _tilemap.color;
        c.a = 0;
        _tilemap.color = c;
        _isHidding = false;
    }
}
