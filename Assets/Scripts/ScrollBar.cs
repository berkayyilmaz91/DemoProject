using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollBar : MonoBehaviour
{

    private Vector3 screenSpace;
    private Vector3 offset;
    public static float brushFactory;
 
    public int collisionNumber = 0;
  

    private void Update()
    {
        if (transform.position.x <= 0.5f)
        {
            transform.position = new Vector3(0.5f, transform.position.y, transform.position.z);
        }
        else if (transform.position.x >= 4)
        {
            transform.position = new Vector3(4, transform.position.y, transform.position.z);
        }
        brushFactory = transform.position.x;
        
    }

    private void OnMouseDown()
    {

        screenSpace = Camera.main.WorldToScreenPoint(transform.position);
        offset = transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenSpace.z));
        

    }
    private void OnMouseDrag()
    {

        Vector3 curScreenSpace = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenSpace.z);
        Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenSpace) + offset;
        transform.position = new Vector3(curPosition.x, transform.position.y, curPosition.z);
  
    }

}
