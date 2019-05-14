using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Copiar_Movimiento_Camara : MonoBehaviour
{
    

    float horizontalSpeed = 2;
    float verticalSpeed = 2;

    float h;
    float v;


    private void Update()
    {
        h = horizontalSpeed * Input.GetAxis("Mouse X");
        v = verticalSpeed * Input.GetAxis("Mouse Y");

        transform.Rotate(-v, h, 0);


    }


    /* public Transform playerTransform;

     float x;
     float y;
     float z;

     void Update()
     {
         x = playerTransform.rotation.eulerAngles.x;
         y = playerTransform.rotation.eulerAngles.y;
         z = playerTransform.rotation.eulerAngles.z;

         transform.rotation = Quaternion.Euler(x, 0, 0);
         transform.rotation = Quaternion.Euler(0, y, 0);
         transform.rotation = Quaternion.Euler(0, 0, z);
     } */
}
