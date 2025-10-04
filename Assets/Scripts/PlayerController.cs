using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float playerSpeed = 10;
    public float gravityForce = 0.8f;
    private CharacterController controller;

    
    void Start() // Start is called before the first frame update
    {
        controller = GetComponent<CharacterController>();
    }
    
    void Update() // Update is called once per frame
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 movement = transform.right * x + transform.forward * z + transform.up * -gravityForce;
        movement *= Time.deltaTime * playerSpeed;
        movement += transform.up * -gravityForce * Time.deltaTime;

        controller.Move(movement);
    }
}
