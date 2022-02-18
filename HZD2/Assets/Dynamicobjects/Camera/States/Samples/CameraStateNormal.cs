using UnityEngine;

[CreateAssetMenu(fileName = "CameraState", menuName = "Camera/NormalState")]
public class CameraStateNormal : CameraState
{
    [SerializeField] private Vector2 _verticalBorder;
    [SerializeField] private Vector2 _horizontalBorder;
    
    [SerializeField] private float speed = 1f;
    [SerializeField] private float mouseSpeed = 1f;

    private float screenX;
    private float screenY;

    [SerializeField] private Vector3 offset;
    private Vector2 newPos;
    private Vector3 mouse;
    private Vector3 _newPosition;

    public override void Init()
    {
        screenX = Screen.width / 2;
        screenY = Screen.height / 2;
    }

    public override void Run()
    {
        mouse = new Vector3(Input.mousePosition.x - screenX, Input.mousePosition.y - screenY, 0f);
        _newPosition = camera.purpose.transform.position + offset + mouse * mouseSpeed * Time.fixedDeltaTime;
        newPos.x = Mathf.Lerp(_newPosition.x, camera.transform.position.x, speed);
        newPos.y = Mathf.Lerp(_newPosition.y, camera.transform.position.y, speed);

        if (camera.transform.position.x != _horizontalBorder.x && camera.transform.position.x != _horizontalBorder.y)
        {
            velocity = _newPosition.x - camera.transform.position.x;
        }
        else
        {
            velocity = 0;
        }
        
        if (Mathf.Abs(newPos.x) + Mathf.Abs(newPos.y) > 0.05f)
        {
            camera.transform.position = new Vector3(Mathf.Clamp(newPos.x, _horizontalBorder.x, _horizontalBorder.y), Mathf.Clamp(newPos.y, _verticalBorder.x, _verticalBorder.y), offset.z);
        }
    }
}
