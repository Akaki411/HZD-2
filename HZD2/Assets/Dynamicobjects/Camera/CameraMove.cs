using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [SerializeField] private CameraState normalState;
    [SerializeField] private Gradient _skyGradient;
    [SerializeField] private float _changeColorSpeed = 0.05f;
    private CameraState currentState;
    private float _colorPosition = 0;
    
    public GameObject purpose {get; private set;}
    public Camera camera {get; private set;}

    private void Start()
    {
        camera = GetComponent<Camera>();
        purpose = GameObject.FindGameObjectsWithTag("Player")[0];
        currentState = normalState;
        currentState.camera = this;
        currentState.Init();
    }

    private void FixedUpdate()
    {
        currentState.Run();
    }

    public void Blackout()
    {
        StartCoroutine(SetBGColorLight());
    }

    public void Dawn()
    {
        StartCoroutine(SetBGColorDark());
    }

    private IEnumerator SetBGColorLight()
    {
        for(float i = _colorPosition; i <= 1f; i += _changeColorSpeed)
        {
            camera.backgroundColor = _skyGradient.Evaluate(i);
            _colorPosition = i;
            yield return null;
        }
        camera.backgroundColor = _skyGradient.Evaluate(1);
        _colorPosition = 1f;
    }

    private IEnumerator SetBGColorDark()
    {
        for(float i = _colorPosition; i >= 0; i -= _changeColorSpeed)
        {
            camera.backgroundColor = _skyGradient.Evaluate(i);
            _colorPosition = i;
            yield return null;
        }
        camera.backgroundColor = _skyGradient.Evaluate(0);
        _colorPosition = 0;
    }
}
