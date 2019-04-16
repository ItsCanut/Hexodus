using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Punto : MonoBehaviour
{

    public float VidaTorre = 1000f;
    
    // Start is called before the first frame update

    public void AplicarDañoTorre(float amount)
    {
        VidaTorre -= amount;
       
        if (VidaTorre <= 0f)
        {
           
                
        }
    }
}
