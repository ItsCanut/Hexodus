﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VidaP : MonoBehaviour
{
    public float vida = 100f;
    //public GameObject vidahud;

    public Scrollbar HealthBar;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
  public void AplicarDano(int dano)
    {
        vida -= dano;

        //Text text = vidahud.GetComponent<Text>();

       // int vida2 = Convert.ToInt16(text.ToString());

       // vida2 = vida - dano;

        //text.text = vida.ToString();

        HealthBar.size = vida / 100f;


        if (vida <=0f)
        {
            Destroy(gameObject);
            
        }

    }  

}
