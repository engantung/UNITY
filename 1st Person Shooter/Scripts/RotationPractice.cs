using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationPractice : MonoBehaviour
{
    public GameObject redCube;
    private float rotateSpeed = 10f;
    void Update()
    {
            if (Input.GetMouseButton(0))
        {
            float h = rotateSpeed * Input.GetAxis("Mouse X");
            
            float v = rotateSpeed * Input.GetAxis("Mouse Y");
            redCube.transform.Rotate(v, -h,0,Space.World);
        }
    }
}
