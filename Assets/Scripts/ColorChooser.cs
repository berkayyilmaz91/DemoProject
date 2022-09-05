using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ColorChooser : MonoBehaviour
{
    public static int colorIndex = 0;
   


    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject.tag == "blue")
                {
                    colorIndex = 0;
                }
                if (hit.collider.gameObject.tag == "red")
                {
                    colorIndex = 1;
                }
                if (hit.collider.gameObject.tag == "yellow")
                {
                    colorIndex = 2;
                }
               
            }

        }

    }
}
