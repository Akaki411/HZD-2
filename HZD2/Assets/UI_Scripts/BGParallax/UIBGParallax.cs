using UnityEngine;

public class UIBGParallax : MonoBehaviour
{
    [SerializeField] private float _sensetivity;
    [SerializeField] private float _speed;
    private float _newPosition = 0;
    private float _different = 0;
    private void FixedUpdate()
    {
        _newPosition = MenuCamera.mousePosition.x * _sensetivity;
        _different = transform.position.x - _newPosition;
        if (Mathf.Abs(_different) > 0.05f)
        {
            transform.position = new Vector2(Mathf.Lerp(transform.position.x, _newPosition, _speed), transform.position.y);
        }
    }
}
