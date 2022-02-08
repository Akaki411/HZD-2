using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalLight : MonoBehaviour
{
    [SerializeField] private float _maxLightning = 1f;
    [SerializeField] private float _minLightning = 0f;
    [SerializeField] private float _speed = 0.1f;
    [SerializeField] private Light _light;

    public void IncreaceIntensity()
    {
        StartCoroutine(IntenUp());
    }

    public void DecreaceIntensity()
    {
        StartCoroutine(IntenDown());
    }

    private IEnumerator IntenUp()
    {
        for(float i = _light.intensity; i <= _maxLightning; i += _speed)
        {
            _light.intensity = i;
            yield return null;
        }
        _light.intensity = _maxLightning;
    }

    private IEnumerator IntenDown()
    {
        for(float i = _light.intensity; i >= _minLightning; i -= _speed)
        {
            _light.intensity = i;
            yield return null;
        }
        _light.intensity = _minLightning;
    }
}
