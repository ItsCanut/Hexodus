using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidaBoss : MonoBehaviour
{
    // Start is called before the first frame update
    public float health = 1000f;
    public GameObject expl;
    public Transform posi;
    // Start is called before the first frame update

    public void AplicarDaño(float amount)
    {
        health -= amount;
        if (health <= 0f)
        {
            GameObject exp = Instantiate(expl, posi.position, Quaternion.identity);
            Destroy(gameObject);

            

            Destroy(exp, 1f);
        }
    }
}
