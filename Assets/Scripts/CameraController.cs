using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Vector2 _screenBottomLeft;
    private Vector2 _screenTopRight;
    public new Camera camera;

    void Start()
    {
        if (camera == null)
        {
            camera = Camera.main;
        }
        GetScreenPos();
    }

    void GetScreenPos()
    {
        _screenBottomLeft = camera.ScreenToWorldPoint(Vector3.zero);
        
        _screenTopRight = camera.ScreenToWorldPoint(
            new Vector3(Screen.width, Screen.height, transform.position.z)
        );
    }
}
