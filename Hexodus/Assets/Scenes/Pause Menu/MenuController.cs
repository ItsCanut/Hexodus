using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    
    public GameObject pauseMenu;
    public GameObject Ayuda;
    public GameObject Ayudas;
    public bool isPaused;
    public Transform robot;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.visible = true;

            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                Robot robott = robot.GetComponent<Robot>();
                robott.aS.Pause();
                Cursor.lockState = CursorLockMode.Locked;
                isPaused = true;
                pauseMenu.SetActive(true);
                Ayuda.SetActive(false);
                Ayudas.SetActive(false);
                Time.timeScale = 0f;        // Speed time runs (frozen)
            }
        }
    }

    public void ResumeGame()
    {
        isPaused = false;
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;        // unfrozen
    }

    public void ReturnToMain()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    
}
