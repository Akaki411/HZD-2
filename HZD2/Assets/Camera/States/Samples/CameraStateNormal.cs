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

    public override void Init()
    {
        screenX = Screen.width / 2;
        screenY = Screen.height / 2;
    }

    public override void Run()
    {
        if (size != camera.camera.orthographicSize)
        {
            camera.camera.orthographicSize = Mathf.SmoothStep(camera.camera.orthographicSize, size, sizeSpeed);
        }

        mouse = new Vector3(Input.mousePosition.x - screenX, Input.mousePosition.y - screenY, 0f);

        camera.transform.position = Vector3.Lerp(camera.transform.position, camera.purpose.transform.position + offset + mouse * mouseSpeed * Time.deltaTime, speed);
    }

    public override void ChangeSize(float size)
    {
        this.size = size;
    }
}
