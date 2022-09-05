using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShiningObstacleControl : MonoBehaviour
{

    private float angle = 0;
    private float xPosition;
    private float speed = 0.003f;
    private bool infEdgeControl = false, supEdgeControl = true;
    private float edge = 0.63f;
    public Color newColor;
    private MeshRenderer renderer;

    private void Start()
    {
        xPosition = transform.position.x;


        renderer = transform.GetComponent<MeshRenderer>();

    }

    void ApplyMetarial(Color color)
    {
        Material generatedMaterial = new Material(Shader.Find("Standard"));
        generatedMaterial.SetColor("_Color", color);


        renderer.material = generatedMaterial;

    }
    void Update()
    {
        transform.localEulerAngles = new Vector3(0, angle++ * 1f, 0);
        if (angle == +3600.0f)
        {
            angle = 0;
        }

        XMovement();

    }
    private void XMovement()
    {
        if (supEdgeControl)
        {

            transform.position = new Vector3(xPosition-- * speed, transform.position.y, transform.position.z);
            if (transform.position.x < -edge)
            {
                infEdgeControl = true;
                supEdgeControl = false;
            }

        }
        if (infEdgeControl)
        {

            transform.position = new Vector3(xPosition++ * speed, transform.position.y, transform.position.z);
            if (transform.position.x > edge)
            {
                supEdgeControl = true;
                infEdgeControl = false;
            }

        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        newColor = Random.ColorHSV();
        ApplyMetarial(newColor);
    }
}
