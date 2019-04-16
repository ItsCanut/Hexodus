using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Punto : MonoBehaviour
{

    public float VidaTorre = 1000f;
    public Scrollbar HealthBar;
    public GameObject VidaCast;
    Image image;
    private int cont = 0;
    public Sprite cas1;
    public Sprite cas2;
    public Sprite cas3;
    public Sprite cas4;

    void Update()
    {
        image = VidaCast.GetComponent<Image>();
    }
    public void AplicarDañoTorre(float amount)
    {


        VidaTorre -= amount;
        cont++;

        if (cont==1)
        {

            Debug.Log("Hola1");
            image.sprite = cas1;

        }
        if (cont == 2)
        {
            Debug.Log("Hola2");
            image.sprite = cas2;

        }
        if (cont == 3)
        {
            Debug.Log("Hola3");
            image.sprite = cas3;

        }
        if (cont == 4)
        {
            image.sprite = cas4;
            SceneManager.LoadScene("start");
        }

        
    }
}
