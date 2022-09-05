using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatorControl1 : MonoBehaviour
{
    private float angle;
    void Update()
    {
        transform.localEulerAngles = new Vector3(0, angle-- * 1f, 0);
        if (angle == -3600.0f)
        {
            angle = 0;
        }
    }
}
