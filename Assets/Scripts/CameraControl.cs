using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    [SerializeField] private float mouseSensivity = 200;

    private Transform parent;

    void Start()
    {
        parent = transform.parent;
    }

 
    void Update()
    {
        Rotate();
    }
    private void Rotate()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensivity * Time.deltaTime;
        if (Input.GetMouseButton(1))
        {
            parent.Rotate(Vector3.up, mouseX);
          
        }
    }
}
