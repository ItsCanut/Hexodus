using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidaIA : MonoBehaviour
{
    public float health = 50f;
    public GameObject explotion;
    // Start is called before the first frame update
    
    public void AplicarDaño(float amount)
    {
        health -= amount;
        if( health<= 0f)
        {

            Instantiate(explotion,transform.position,transform.rotation);
            Destroy(gameObject);
           
        }
    }
}
