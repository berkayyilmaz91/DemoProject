using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationControlR : MonoBehaviour
{
   private float angle;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.localEulerAngles = new Vector3(0, 0, angle-- * 0.8f);
        if (angle == -3600.0f)
        {
            angle = 0;
        }
    }
}

