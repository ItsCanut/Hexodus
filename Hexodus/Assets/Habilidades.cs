using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Habilidades : MonoBehaviour
{
    public Rigidbody hab;

    public int speed = 20;
    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(1))              
        {
            var clone = Instantiate(hab, transform.position, transform.rotation);
            clone.velocity = transform.TransformDirection(new Vector3(0, 0, speed));


        }
    }
}
