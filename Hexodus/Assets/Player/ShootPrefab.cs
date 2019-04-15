using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootPrefab : MonoBehaviour
{
    public Rigidbody bullet;
   
    public int speed = 20;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var clone = Instantiate(bullet,transform.position, transform.rotation);
            clone.velocity = transform.TransformDirection(new Vector3(0, 0, speed));

           
        }
    }
}
