using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public Transform player;
    public float mouseSensitivity = 2f;
    float cameraVerticalRotation = 0f;
    public bool lockedCursor = true;
    [HideInInspector] public bool CanINPUT;
    
    void Start()
    {
        
    }

    void Update()
    {
        if (lockedCursor == true)
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
        else
        {
            Cursor.visible = true;
            Cursor.lockState = 0;
        }
        if (CanINPUT == true)
        {
            MouseControl();
        }
    }

    private void MouseControl()
    {
        float inputX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float inputY = Input.GetAxis("Mouse Y") * mouseSensitivity;
        
        cameraVerticalRotation -= inputY;
        cameraVerticalRotation = Mathf.Clamp(cameraVerticalRotation , -90f , 90f);
        transform.localEulerAngles = Vector3.right * cameraVerticalRotation;

        player.Rotate(Vector3.up * inputX);
}
}