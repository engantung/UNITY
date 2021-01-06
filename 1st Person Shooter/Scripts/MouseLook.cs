using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{  
    float mousSensitivity = 100f;
    float xRotation = 0f;
    public Transform playerBody;


    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mousSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mousSensitivity * Time.deltaTime;

        playerBody.Rotate(Vector3.up * mouseX);

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation,-90,90);
        transform.localRotation = Quaternion.Euler(xRotation, 0f,0f);
    }
}
