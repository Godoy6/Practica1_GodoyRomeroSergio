using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public PlayerController player;
    public float mouseSens = 1000f;
    private float yRotation = 0f;

    void Start() // Start is called before the first frame update
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update() // Update is called once per frame
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSens * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSens * Time.deltaTime;

        yRotation -= mouseY;
        if(yRotation >= 90)
        {
            yRotation = 90;
        }
        if(yRotation <= -90)
        {
            yRotation = -90;
        }
        transform.localRotation = Quaternion.Lerp(transform.localRotation, Quaternion.Euler(yRotation, 0, 0), 1);

        player.transform.Rotate(Vector3.up * mouseX);
    }
}
