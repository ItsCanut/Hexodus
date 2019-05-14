using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipal : MonoBehaviour
{

    public GameObject menuOpciones;             // Menu para editar las opciones del juego
    public GameObject menuPrincipal;            // Menu para acceder al juego, acceder a las opciones y salir del juego

    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Time.timeScale = 1f;
    }

    // -------------------------------------------------------------------------
    // ----------------------- Play Game ---------------------------------------
    // -------------------------------------------------------------------------
    // ------------------------------------------ Abre la ventana de juego -----

    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }


    // -------------------------------------------------------------------------
    // ----------------------------- Salir -------------------------------------
    // -------------------------------------------------------------------------
    // ---------------------------------------- Cierra el juego ----------------

    public void Salir()
    {
        Debug.Log("SALIR DEL JUEGO");
        Application.Quit();
    }


    // -------------------------------------------------------------------------
    // -------------------- Abrir Menu Opciones --------------------------------
    // -------------------------------------------------------------------------
    // ------------------------------------------ Abre el menu de opciones------

        public void AbrirMenuOpciones()
    {
        menuOpciones.gameObject.SetActive(true);
        menuPrincipal.gameObject.SetActive(false);
    }

    // -------------------------------------------------------------------------
    // ---------------------- Volver Al Menu -----------------------------------
    // -------------------------------------------------------------------------
    // ------------------------------------------ Vuelve al menu principal -----

    public void VolverAlMenu()
    {
        menuOpciones.gameObject.SetActive(false);
        menuPrincipal.gameObject.SetActive(true);
    }
}
