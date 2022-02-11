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
    private float difference;

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
        if (Mathf.Abs(camera.camera.orthographicSize - size) > 0.05f)
        {
            camera.camera.orthographicSize = Mathf.SmoothStep(camera.camera.orthographicSize, size, sizeSpeed);
        }

        mouse = new Vector3(Input.mousePosition.x - screenX, Input.mousePosition.y - screenY, 0f);
        _newPosition = camera.purpose.transform.position + offset + mouse * mouseSpeed * Time.fixedDeltaTime;
        difference = Mathf.Abs(camera.transform.position.x - _newPosition.x) + Mathf.Abs(camera.transform.position.y - _newPosition.y);

        if (difference > 0.05f)
        {
            camera.transform.position = Vector3.Lerp(camera.transform.position, _newPosition, speed);
        }
    }

    public override void ChangeSize(float size)
    {
        this.size = size;
    }
}
