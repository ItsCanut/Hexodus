using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidaBoss : MonoBehaviour
{
    // Start is called before the first frame update
    public float health = 1000f;
    // Start is called before the first frame update

    public void AplicarDaño(float amount)
    {
        health -= amount;
        if (health <= 0f)
        {

            Destroy(gameObject);
        }
    }
}
