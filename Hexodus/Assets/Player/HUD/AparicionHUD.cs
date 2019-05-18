using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AparicionHUD : MonoBehaviour
{
    public GameObject HUD;
    public GameObject Ayuda;
    public GameObject AyudaInicio;
    public GameObject Ayudas;
    private int isOn = 0;
    private int tiempo = 0;

    // Start is called before the first frame update
    void Start()
    {
        Ayuda.SetActive(true);
        Ayudas.SetActive(false);
        StartCoroutine(Tiempo());
    }

    // Update is called once per frame
    void Update()
    {
        if (tiempo == 1)
        {
            if (Input.GetKeyDown(KeyCode.I))
            {
                if (isOn == 0)
                {
                    Ayuda.SetActive(true);
                    AyudaInicio.SetActive(false);
                    Ayudas.SetActive(true);
                    isOn = 1;
                }
                else
                {
                    Ayuda.SetActive(false);
                    Ayudas.SetActive(false);
                    isOn = 0;
                }
            }
        }

    }

    IEnumerator Tiempo()
    {        
        yield return new WaitForSeconds(4);
        tiempo = 1;
        HUD.SetActive(true);
        Ayuda.SetActive(false);
    }
     
}
