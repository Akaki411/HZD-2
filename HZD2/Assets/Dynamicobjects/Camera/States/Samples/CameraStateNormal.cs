using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CameraState", menuName = "Camera/NormalState")]
public class CameraStateNormal : CameraState
{
    [SerializeField] private float speed = 1f;
    [SerializeField] private float mouseSpeed = 1f;
    [SerializeField] private float size = 5f;
    [SerializeField] private float sizeSpeed = 1f;
    
    
    private float screenX;
    private float screenY;

    [SerializeField] private Vector3 offset;
    private Vector3 mouse;
    private Vector3 _newPosition;

    public override void Init()
    {
        screenX = Screen.width / 2;
        screenY = Screen.height / 2;
    }

    public override void Run()
    {
        if (Mathf.Abs(camera.mainCamera.orthographicSize - size) > 0.01f)
        {
            camera.mainCamera.orthographicSize = Mathf.SmoothStep(camera.mainCamera.orthographicSize, size, sizeSpeed);
        }

        mouse = new Vector3(Input.mousePosition.x - screenX, Input.mousePosition.y - screenY, 0f);
        _newPosition = camera.purpose.transform.position + offset + mouse * mouseSpeed * Time.fixedDeltaTime;
        velocity.x = Mathf.Lerp(_newPosition.x, camera.transform.position.x, speed);
        velocity.y = Mathf.Lerp(_newPosition.y, camera.transform.position.y, speed);
        
        if (Mathf.Abs(velocity.x) + Mathf.Abs(velocity.y) > 0.05f)
        {
            camera.transform.position = new Vector3(velocity.x, velocity.y, offset.z);
        }
    }

    public override void ChangeSize(float size)
    {
        this.size = size;
    }
}
