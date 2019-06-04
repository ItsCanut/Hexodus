using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbrirTienda : MonoBehaviour
{

    public GameObject tiendaFisica;
    public GameObject tiendaCanvas;
    
    public GameObject menuPausa;        // Menu de opciones cuando el jugador pausa el juego
    public GameObject menuInGame;      // HUD del juego la cual otorga info al jugador
    public GameObject menuGameOver;   // Menu cuando el jugador pierde la partida

    public bool isPaused;               // Verifica si está o no pausado el juego


    // Start is called before the first frame update
    void Start()
    {
        isPaused = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            if (isPaused)
            {
                CloseShop();
            }
            if (!isPaused)
            {
                OpenShop();
            }
        }
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if(Physics.Raycast(ray,out hit, 100.0f))
            {
                if(hit.transform != null)
                {
                    if(hit.transform.gameObject == tiendaFisica)
                    {
                        
                            OpenShop();
                        
                    }
                }
            }
        }
    }

    public void OpenShop()
    {
        isPaused = true;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        menuInGame.gameObject.SetActive(false);
        menuGameOver.gameObject.SetActive(false);
        tiendaCanvas.gameObject.SetActive(true);
        menuPausa.gameObject.SetActive(false);
        Time.timeScale = 0f;        // Speed time runs (frozen)
    }

    public void CloseShop()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        isPaused = false;
        menuInGame.gameObject.SetActive(true);
        menuGameOver.gameObject.SetActive(false);
        tiendaCanvas.gameObject.SetActive(false);
        menuPausa.gameObject.SetActive(false);
        Time.timeScale = 1f;        // Speed time runs (frozen)
    }
}
