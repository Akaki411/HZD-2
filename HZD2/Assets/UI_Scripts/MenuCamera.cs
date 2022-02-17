using UnityEngine;

public class MenuCamera : MonoBehaviour
{
    public static Vector2 mousePosition = new Vector2(0, 0);
    private void Update()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
}
