using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CaracteristicasHielo : MonoBehaviour
{
    public float daño = 5f;
    public ParticleSystem part;
    public Transform robot;
    public bool Estado = false;

    public List<ParticleCollisionEvent> collisionEvents;
    Robot roboto;

    void Start()
    {
        part = GetComponent<ParticleSystem>();
        collisionEvents = new List<ParticleCollisionEvent>();
        roboto = robot.GetComponent<Robot>();

        
    }
   

    void OnParticleCollision(GameObject other)
    {
        other.transform.SendMessage("AplicarDaño", daño, SendMessageOptions.DontRequireReceiver);

        if (other.transform.CompareTag("Enemigo"))
        {
            StartCoroutine("Cont");
        }
        
    }

    IEnumerator Cont()
    {
        yield return new WaitForSeconds(1);
        Estado = true;
    }

}
