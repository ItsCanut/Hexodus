using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VidaHUD : MonoBehaviour
{

    public int vida;
    public GameObject barraVida;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CambiarVida(int dano)
    {
        Scrollbar barra = barraVida.GetComponent<Scrollbar>();

        vida = vida - dano;

        barra.size = vida * (1/100000);



    }
}
