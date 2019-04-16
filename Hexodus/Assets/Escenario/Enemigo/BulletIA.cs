using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletIA : MonoBehaviour
{
    public int daño = 100;

    private void OnCollisionEnter(Collision collision)
    {
        collision.transform.SendMessage("AplicarDano", daño, SendMessageOptions.DontRequireReceiver);

        Destroy(this.gameObject);
    }
}
