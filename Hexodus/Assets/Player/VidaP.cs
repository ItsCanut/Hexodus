using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class VidaP : MonoBehaviour
{
    public float vida = 10000f;    
    public Scrollbar HealthBar;

    public int oro = 0;
    public int hierro = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void ContarMateriales(int _oro, int _hierro)
    {
        oro += _oro;
        Debug.Log("--Tienes " + oro + " de oro--");
        hierro += _hierro;
        Debug.Log("--Tienes " + hierro + " de hierro--");
    }

    // Update is called once per frame
  public void AplicarDano(float dano)
    {
        vida -= dano;
        HealthBar.size = vida / 100f;

        if (vida <=0f)
        {
            SceneManager.LoadScene("Start");
        }

    }  

}
