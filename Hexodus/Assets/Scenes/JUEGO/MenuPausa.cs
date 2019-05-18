using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPausa : MonoBehaviour
{

    public GameObject menuTienda;       // Menu de la tienda ingame
    public GameObject menuPausa;        // Menu de opciones cuando el jugador pausa el juego
    public GameObject menuInGame;      // HUD del juego la cual otorga info al jugador
    public GameObject menuGameOver;   // Menu cuando el jugador pierde la partida
    public GameObject Ayuda;          // Canvas Ayuda entero
    public GameObject Ayudas;         // Hints
    public bool isAyuda = false;               
    public bool isPaused;               // Verifica si está o no pausado el juego
    public GameObject personaje;        // Se utiliza para modificar los atributos del personaje al comprar en la tienda

    private bool tiendaAbierta;

    void Start()
    {
        Debug.Log("HE NACIDO");
        isPaused = false;
        tiendaAbierta = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {                                       // al dar click en la tecla "escape"
            
            if (isPaused)
            {                                   // Al dar click en "escape" estando el juego ya parado
                ResumeGame();
                //Cursor.visible = false;
                //Cursor.lockState = CursorLockMode.Locked;
                Debug.Log("Jugando");
                if (isAyuda)
                {
                    isAyuda = false;
                    Ayuda.SetActive(true);
                }
            }
            else {
                PauseGame();
                Debug.Log("Juego PARADO");
                if (Ayuda.active)
                {
                    isAyuda = true;
                    Ayuda.SetActive(false);
                }
                
            }
        }

        if (Input.GetKeyDown(KeyCode.T))
        {
            if (tiendaAbierta)
            {
                CloseShop();
            }
            else
            {
                OpenShop();
            }
        }
    }


    // -------------------------------------------------------------------------------------------
    // --------------------------- Pause Game ----------------------------------------------------
    // -------------------------------------------------------------------------------------------
    // --------------------------------------- Pausa el juego y muestra el menu de pausa ---------


    public void PauseGame()
    {
        isPaused = true;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        menuInGame.gameObject.SetActive(false);
        menuGameOver.gameObject.SetActive(false);
        menuTienda.gameObject.SetActive(false);
        menuPausa.gameObject.SetActive(true);
        Time.timeScale = 0f;        // Speed time runs (frozen)
    }




    // -------------------------------------------------------------------------------------------
    // --------------------------- Resume Game ---------------------------------------------------
    // -------------------------------------------------------------------------------------------
    // --------------------------- Cierra el menu de pausa y vuelve a la partida donde se dejó ---


    public void ResumeGame()                   
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        isPaused = false;
        menuTienda.gameObject.SetActive(false);
        menuPausa.gameObject.SetActive(false);
        menuGameOver.gameObject.SetActive(false);
        menuInGame.gameObject.SetActive(true);
        Time.timeScale = 1f;        // unfrozen
    }




    // -------------------------------------------------------------------------------------------
    // --------------------------- Return to Main-------------------------------------------------
    // -------------------------------------------------------------------------------------------
    // ------------------------------------- Se cierra la partida y se vuelve al menu principal --

    public void ReturnToMain()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }


    // ---------------------------------------------------------------------------------------
    // --------------------------- Open Shop -------------------------------------------------
    // ---------------------------------------------------------------------------------------
    // ------------------------------------- Se abre la pestaña de la tienda -----------------

    public void OpenShop()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        menuTienda.gameObject.SetActive(true);
        menuInGame.gameObject.SetActive(false);
        menuPausa.gameObject.SetActive(false);
        menuGameOver.gameObject.SetActive(false);
        personaje.GetComponent<Camera_Control>().enabled = false;
    }

    // Cierra la pestaña de tienda
    public void CloseShop()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        menuTienda.gameObject.SetActive(false);
        menuInGame.gameObject.SetActive(true);
        personaje.GetComponent<Camera_Control>().enabled = true;

    }


}
