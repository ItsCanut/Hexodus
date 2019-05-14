using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletIA : MonoBehaviour
{
    public float daño = 2f;

    private void OnCollisionEnter(Collision collision)
    {
        collision.transform.SendMessage("AplicarDano", daño, SendMessageOptions.DontRequireReceiver);

        Destroy(this.gameObject);
    }
}
