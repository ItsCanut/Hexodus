using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CaracteristicasHielo : MonoBehaviour
{
    public float daño = 5f;
    public ParticleSystem part;
    public GameObject robot;
    public List<ParticleCollisionEvent> collisionEvents;

    void Start()
    {
        part = GetComponent<ParticleSystem>();
        collisionEvents = new List<ParticleCollisionEvent>();
    }

    void OnParticleCollision(GameObject other)
    {
        other.transform.SendMessage("AplicarDaño", daño, SendMessageOptions.DontRequireReceiver);


        
    }

}
