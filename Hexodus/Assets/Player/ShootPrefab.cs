using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootPrefab : MonoBehaviour
{
    public Rigidbody bullet;
    public float shootRate;
    private float m_shootRateTimeStamp;
    public int speed = 20;


    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButton(0))
        {
            if (Time.time > m_shootRateTimeStamp)
            {
                var clone = Instantiate(bullet, transform.position, transform.rotation);
                clone.velocity = transform.TransformDirection(new Vector3(0, 0, speed));
                m_shootRateTimeStamp = Time.time + shootRate;
            }
        }
    }
}
