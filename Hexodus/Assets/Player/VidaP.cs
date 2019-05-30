using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class VidaP : MonoBehaviour
{
    public float vida ;    
    public Image HealthBar;
    public GameObject orico;
    public GameObject Ayuda;
    public GameObject loHierro;
    public GameObject laPuntuacion;
    public GameObject losOrbesitos;
    public GameObject menuMuerte;

    private float tiempo;
    public float RecVida ;

    public int oro = 0;
    public int hierro = 0;
    public int puntuacion = 0;
    public int orbesitos = 0;
    public AudioClip explosion;
    public AudioSource eplosionOriginal;

    public CameraShake camara;
    public Transform laCamara;

    float tiempolleva = 0f;
    float tiempoHasta = 0f;

    int puntGuardada;
    bool guardarPunt;
    bool cont;

    Text or;
    Text orb;
    Text fer;
    Text punt;

    // Start is called before the first frame update
    void Start()
    {
        or = orico.GetComponent<Text>();
        fer = loHierro.GetComponent<Text>();
        orb = losOrbesitos.GetComponent<Text>();
        punt = laPuntuacion.GetComponent<Text>();
        puntGuardada = PlayerPrefs.GetInt("Puntuacion");
        guardarPunt = false;
        cont = false;


        eplosionOriginal.clip = explosion;
    }

    void Update()
    {


        if (Time.time > tiempo)
        {
            if (vida < 1000)
            {
                vida += 15f;
                HealthBar.fillAmount = vida / 1000;
            }


            tiempo = Time.time + RecVida;
        }

        if (puntuacion > PlayerPrefs.GetInt("Puntuacion"))
        {
            PlayerPrefs.SetInt("Puntuacion", puntuacion);
            Debug.Log("Se ha cambiado la puntuacion");
            PlayerPrefs.Save();

        }

    }

    public void ContarOrbes( int _orbes)
    {
        orbesitos += _orbes;
        Debug.Log(orbesitos);
        orb.text = orbesitos.ToString();
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

    public void subirPuntuacion(int _puntuacion)
    {
        puntuacion += _puntuacion;
        punt.text = puntuacion.ToString();
        Debug.Log("--Puntuacion: " + puntuacion);
    }

    // Update is called once per frame
  public void AplicarDano(float dano)
    {
        eplosionOriginal.Play();
        //camara = GetComponent<CameraShake>();
        CameraShake a = laCamara.GetComponent<CameraShake>();
        Debug.Log("Shake camera...");
        a.shakeDuration = 0.1f;
        a.shakeAmount = 0.25f;
        a.shakecamera();

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

        if (HealthBar.fillAmount <= 0.20  )
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
