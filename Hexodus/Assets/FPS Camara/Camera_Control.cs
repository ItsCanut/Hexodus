﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Control : MonoBehaviour
{

    public Camera FPSCamera;

    public float horizontalSpeed;
    public float verticalSpeed;

    float h;
    float v;

    void Start()
    {
        
    }


    private void Update()
    {
        h = horizontalSpeed * Input.GetAxis("Mouse X");
        v = verticalSpeed * Input.GetAxis("Mouse Y");

        transform.Rotate(0, h, 0);
        FPSCamera.transform.Rotate(-v, 0, 0);

        
    }














    /*
    public enum RotationAxis
    {
        MouseX = 1,
        MouseY = 2
    }

    public RotationAxis axes = RotationAxis.MouseX;

    public float minimumVert = -45.0f;
    public float maximumVert = 45.0f;

    public float sensHorizontal = 10.0f;
    public float sensVertical = 10.0f;

    public float _rotationX = 0;


    // Update is called once per frame
    void Update()
    {
        if(axes == RotationAxis.MouseX){
            transform.Rotate(0, Input.GetAxis("Mouse X") * sensHorizontal, 0);
        } else if (axes == RotationAxis.MouseY)
        {
            _rotationX -= Input.GetAxis("MouseY") * sensVertical;

            float rotationY = transform.localEulerAngles.y;

            transform.localEulerAngles = new Vector3(_rotationX, rotationY, 0);
        }

    }

    */
}
