using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HechizoSuelo : MonoBehaviour
{
    public float daño = 100f;

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

        Debug.Log(other.name);
    }
}
