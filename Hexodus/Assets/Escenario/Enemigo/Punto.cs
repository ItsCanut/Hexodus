using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Punto : MonoBehaviour
{    

    public float VidaTorre = 1000f;
    // Start is called before the first frame update

    public void AplicarDañoTorre(float amount)
    {
        VidaTorre -= amount;
        Debug.Log("----ola q ase----");
        if (VidaTorre <= 0f)
        {
            Debug.Log("Acabas de Palmar Prim");
        }
    }
}
