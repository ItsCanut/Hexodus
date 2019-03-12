using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VidaP : MonoBehaviour
{
    public int vida = 100;
    public GameObject vidahud;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
  public void AplicarDano(int dano)
    {
        vida -= dano;

        Text text = vidahud.GetComponent<Text>();

       // int vida2 = Convert.ToInt16(text.ToString());

       // vida2 = vida - dano;

        text.text = vida.ToString();



        if (vida <=0)
        {
            Destroy(gameObject);
        }

    }  

}
