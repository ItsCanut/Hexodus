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
    public GameObject orico;
    public GameObject loHierro;

    public int oro = 0;
    public int hierro = 0;
    Text or;
    Text fer;

    // Start is called before the first frame update
    void Start()
    {
        or = orico.GetComponent<Text>();
        fer = loHierro.GetComponent<Text>();
    }

    public void ContarMateriales(int _oro, int _hierro)
    {
        oro += _oro;
        or.text = oro.ToString();
        Debug.Log("--Tienes " + oro + " de oro--");

        hierro += _hierro;
        fer.text = hierro.ToString();
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
