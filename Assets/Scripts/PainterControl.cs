using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PainterControl : MonoBehaviour
{

    private Vector3 screenSpace;
    private Vector3 offset;
    public GameObject[] tail;
    public int colorIndex;
    public float zNormalization = 0.25f, xInfLimit = -6.85f, xSupLimit = 6.85f, yInfLimit = 7f, ySupLimit = 0.25f;
    public float brushSizeFactory;

    private void Update()
    {
        colorIndex = ColorChooser.colorIndex;
        brushSizeFactory = ScrollBar.brushFactory*0.15f;

    }

    private void OnMouseDown()
    {

        screenSpace = Camera.main.WorldToScreenPoint(transform.position);
        offset = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenSpace.z));
        tail[colorIndex] = Instantiate(tail[colorIndex], offset, Quaternion.identity);
        tail[colorIndex].GetComponent<TrailRenderer>().widthMultiplier = brushSizeFactory;

    }
    private void OnMouseDrag()
    {

        Vector3 curScreenSpace = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenSpace.z);
        Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenSpace)/* + offset*/;
        tail[colorIndex].transform.position = new Vector3(curPosition.x, curPosition.y, curPosition.z - zNormalization);

        if (tail[colorIndex].transform.position.x <= xInfLimit)
        {
            tail[colorIndex].transform.position = new Vector3(xInfLimit, tail[colorIndex].transform.position.y, tail[colorIndex].transform.position.z);
        }
        if (tail[colorIndex].transform.position.x >= xSupLimit)
        {
            tail[colorIndex].transform.position = new Vector3(xSupLimit, tail[colorIndex].transform.position.y, tail[colorIndex].transform.position.z);
        }

        if (tail[colorIndex].transform.position.y >= yInfLimit)
        {
            tail[colorIndex].transform.position = new Vector3(tail[colorIndex].transform.position.x, yInfLimit, tail[colorIndex].transform.position.z);
        }
        if (tail[colorIndex].transform.position.y <= ySupLimit)
        {
            tail[colorIndex].transform.position = new Vector3(tail[colorIndex].transform.position.x, ySupLimit, tail[colorIndex].transform.position.z);
        }

    }

}
