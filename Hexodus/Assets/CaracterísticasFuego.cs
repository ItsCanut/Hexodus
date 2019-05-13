using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaracterísticasFuego : MonoBehaviour
{
    public float daño = 5f;
    public ParticleSystem part;
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
