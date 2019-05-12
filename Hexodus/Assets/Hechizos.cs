using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hechizos : MonoBehaviour
{
    public ParticleSystem flames;
    public ParticleSystem rocas;
    public Image mana;
    public float Mana = 100f;
    private float tiempo;
    public float RecMana= 2f;

    // Start is called before the first frame update
    void Start()
    {
        flames.Stop();
        rocas.Stop();
    }

    // Update is called once per frame
    void Update()
    {
       
        
     if (Input.GetKey(KeyCode.E))
       {
           
            flames.Play();
            Mana -= 1f;
            mana.fillAmount = Mana / 100;

        }
        else
        {
            flames.Stop();
        }
        if (Input.GetKey(KeyCode.Q))
        {
            rocas.Play();
            Mana -= 1f;
            mana.fillAmount = Mana / 100;

        }
        else
            {
             
            rocas.Stop();
            }
        

        if (Time.time > tiempo)
        {

            Mana += 1f;
            mana.fillAmount = Mana / 100;

            tiempo = Time.time + RecMana;
        }
        
        

    }

   
}
