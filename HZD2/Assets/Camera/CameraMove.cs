using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [SerializeField] private CameraState normalState;
    private CameraState currentState;
    
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

    private void Update()
    {
        currentState.Run();
    }
}
