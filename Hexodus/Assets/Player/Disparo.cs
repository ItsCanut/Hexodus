using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disparo : MonoBehaviour
{
    // Start is called before the first frame update
      public Rigidbody projectile;
    public float speed = 20;
    public AudioClip AudioDisparo ;
    public GameObject efecto;

    private void Start()
    {
        efecto.active = false;
    }
    // Update is called once per frame
    void Update ()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            
            Rigidbody instantiatedProjectile = Instantiate(projectile,transform.position,transform.rotation)as Rigidbody;
            instantiatedProjectile.velocity = transform.TransformDirection(new Vector3(0, 0,speed));
            transform.GetComponent<AudioSource>().PlayOneShot(AudioDisparo);

               efecto.active = true;
            Invoke("FX", 0.2f);
        }
    }


    void FX()
    {
        efecto.active=false;
    }
}
