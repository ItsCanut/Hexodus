﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletHit : MonoBehaviour
{
    public int daño = 100;

    private void OnCollisionEnter(Collision collision)
    {
        collision.transform.SendMessage("AplicarDaño", daño,SendMessageOptions.DontRequireReceiver);

        Destroy(this.gameObject);
    }
}
