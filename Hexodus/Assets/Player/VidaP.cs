using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class VidaP : MonoBehaviour
{
   public  float vida = 100f;    
    public Image HealthBar;
    public GameObject orico;
    public GameObject Ayuda;
    public GameObject loHierro;

    public GameObject menuMuerte;

    private float tiempo;
    public float RecVida = 5f;

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
        HealthBar.fillAmount = vida/1000;

        
        if (HealthBar.fillAmount<= 0.5)
        {
            HealthBar.GetComponent<Image>().color = new Color(0.5f, 0.5f, 0.5f, 1);

        }

        if (HealthBar.fillAmount <= 0.35)
        {
            HealthBar.GetComponent<Image>().color = new Color(1, 0, 1, 1);

        }

        if (HealthBar.fillAmount <= 0.20)
        {
            HealthBar.GetComponent<Image>().color = new Color(1, 0, 0, 1);

        }



        if (vida <=0f)
        {
            Ayuda.SetActive(false);
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            Time.timeScale = 0f;
            menuMuerte.gameObject.SetActive(true);
        }

    }  

}
