using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VidaHUD : MonoBehaviour
{

    public GameObject vidahud;

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
        Text text = vidahud.GetComponent<Text>();

        int vida = Convert.ToInt16(text.ToString());

        vida = vida - dano;

        text.text = vida.ToString();



    }
}
