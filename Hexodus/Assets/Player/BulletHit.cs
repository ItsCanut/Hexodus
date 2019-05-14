using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletHit : MonoBehaviour
{
    public float daño = 10;

    private void OnCollisionEnter(Collision collision)
    {
        collision.transform.SendMessage("AplicarDaño", daño, SendMessageOptions.DontRequireReceiver);

        Destroy(this.gameObject);
    }
}
