using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateMenu : MonoBehaviour
{
    private float rotateSpeed = 10;
      void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    [System.Obsolete]
    private void OnMouseDrag()
    {
        float rotVal = Input.GetAxis("Mouse X") * rotateSpeed * Mathf.Deg2Rad;
        transform.RotateAround(Vector3.up, -rotVal);
    }
}
