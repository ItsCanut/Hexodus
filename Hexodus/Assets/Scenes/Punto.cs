using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Punto : MonoBehaviour
{

    public float VidaTorre = 1000f;
    
    public GameObject VidaCast;
    public GameObject Ayuda;
    Image image;
    
    public Sprite cas1;
    public Sprite cas2;
    public Sprite cas3;
    public Sprite cas4;
    public GameObject expl;

    public CameraShake laCamareta;
    public Transform laPutaCamareta;


    void Update()
    {
        image = VidaCast.GetComponent<Image>();

       
    }
    public void AplicarDañoTorre(float amount)
    {
        CameraShake a = laPutaCamareta.GetComponent<CameraShake>();
        Debug.Log("Shake camera...");
        a.shakeDuration = 0.5f;
        a.shakeAmount = 0.7f;
        a.shakecamera();

        VidaTorre -= amount;

        GameObject exp = Instantiate(expl, transform.position, Quaternion.identity);
        
        Destroy(exp, 1f);


        if (VidaTorre <= 750f)
        {

            Debug.Log("--VidaTorre al 75%--");
            image.sprite = cas1;

        }
        if (VidaTorre <= 500f)
        {
            Debug.Log("--VidaTorre al 50%--");
            image.sprite = cas2;

        }
        if (VidaTorre <= 250f)
        {
            Debug.Log("--VidaTorre al 25%--");
            image.sprite = cas3;

        }
        if (VidaTorre <= 0f)
        {

            Ayuda.SetActive(false);
            Debug.Log("--VidaTorre al 0%--");
            image.sprite = cas4;
            SceneManager.LoadScene("start");
        }

        
    }
}
