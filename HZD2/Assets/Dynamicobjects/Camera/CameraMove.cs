using System.Collections;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [SerializeField] private CameraState normalState;
    [SerializeField] private Gradient _skyGradient;
    [SerializeField] private float _changeColorSpeed = 0.05f;
    private CameraState currentState;
    private float _colorPosition = 0;
    
    public GameObject purpose {get; private set;}
    public Camera mainCamera {get; private set;}
    public static CameraMove singleton { get; private set; }

    private void Start()
    {
        mainCamera = GetComponent<Camera>();
        purpose = GameObject.FindGameObjectsWithTag("Player")[0];
        singleton = this;
        SetState(normalState);
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

    public float GetCameraVelocity()
    {
        return currentState.velocity;
    }

    private IEnumerator SetBGColorLight()
    {
        for(float i = _colorPosition; i <= 1f; i += _changeColorSpeed)
        {
            mainCamera.backgroundColor = _skyGradient.Evaluate(i);
            _colorPosition = i;
            yield return null;
        }
        mainCamera.backgroundColor = _skyGradient.Evaluate(1);
        _colorPosition = 1f;
    }

    private IEnumerator SetBGColorDark()
    {
        for(float i = _colorPosition; i >= 0; i -= _changeColorSpeed)
        {
            mainCamera.backgroundColor = _skyGradient.Evaluate(i);
            _colorPosition = i;
            yield return null;
        }
        mainCamera.backgroundColor = _skyGradient.Evaluate(0);
        _colorPosition = 0;
    }

    private void SetState(CameraState state)
    {
        currentState = state;
        currentState.camera = this;
        currentState.Init();
    }

    public void SetSize(float size)
    {
        currentState.ChangeSize(size);
    }
}
