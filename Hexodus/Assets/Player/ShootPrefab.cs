﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootPrefab : MonoBehaviour
{
    public Rigidbody bullet;
    public float shootRate;
    private float m_shootRateTimeStamp;
    public int speed = 20;
    public GameObject efecto;


    // Update is called once per frame
    void Update()
    {
        efecto.active = false;

        if (Input.GetMouseButton(0))
        {
            if (Time.time > m_shootRateTimeStamp)
            {
                efecto.active = true;
                Invoke("FX", 0.5f);

                var clone = Instantiate(bullet, transform.position, transform.rotation);
                clone.velocity = transform.TransformDirection(new Vector3(0, speed,0 ));
                m_shootRateTimeStamp = Time.time + shootRate;
            }
        }
    }

    void FX()
    {
        efecto.active = false;
    }
}
