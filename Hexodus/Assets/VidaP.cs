using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidaP : MonoBehaviour
{
    int vida = 100;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
  public void AplicarDano(int dano)
    {
        vida -= dano;

        if (vida <=0)
        {
            Destroy(gameObject);
        }

    }  

}
