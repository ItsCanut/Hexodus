using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootPrefab : MonoBehaviour
{
    public Rigidbody bullet;
    public float shootRate;
    private float m_shootRateTimeStamp;
    public int speed = 50;
    public GameObject efecto;
    


    // Update is called once per frame
    void Update()
    {
        efecto.SetActive(false);

        if (Input.GetMouseButton(0))
        {
            if (Time.time > m_shootRateTimeStamp)
            {
                efecto.SetActive(true);
                Invoke("FX", 1f);

                var clone = Instantiate(bullet, transform.position, transform.rotation);
                clone.velocity = transform.TransformDirection(new Vector3(0, speed,0 ));
                m_shootRateTimeStamp = Time.time + shootRate;
            }
        }
    }

    void FX()
    {
        efecto.SetActive(false);
    }
}
