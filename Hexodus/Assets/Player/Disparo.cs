using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Cinemachine.CinemachineTargetGroup;

public class Disparo : MonoBehaviour
{
    // Start is called before the first frame update
      public Rigidbody projectile;
    public float speed = 20f;
    public float Dano = 10f;
    public float range = 500f;
    public AudioClip AudioDisparo ;
    public GameObject efecto;

    public Camera fpsCam;
    private void Start()
    {
        efecto.active = false;
    }
    // Update is called once per frame
    void Update ()
    {
        if (Input.GetButtonDown("Fire1"))
        {


            Shoot();
            
        }
    }


    void FX()
    {
        efecto.active=false;
    }
    void Shoot()
    {
        RaycastHit hit;
        //Rigidbody instantiatedProjectile = Instantiate(projectile, transform.position, transform.rotation) as Rigidbody;
        //instantiatedProjectile.velocity = transform.TransformDirection(new Vector3(0, 0, speed));
        transform.GetComponent<AudioSource>().PlayOneShot(AudioDisparo);
        efecto.active = true;
        Invoke("FX", 0.2f);
        if(Physics.Raycast(fpsCam.transform.position,fpsCam.transform.forward,out hit,range))
        {
            Debug.Log(hit.transform.name);
            VidaIA target = hit.transform.GetComponent<VidaIA>();
            if(target != null)
            {
                
                target.AplicarDaño(Dano);
            }
        }

    }
}
