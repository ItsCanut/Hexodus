using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hechizos : MonoBehaviour
{
    public ParticleSystem flames;
    public ParticleSystem rocas;
    public Image mana;
    public float Mana = 400f;
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
       
        
     if (Input.GetKey(KeyCode.R))
       {
           
            flames.Play();
            if (Mana>0 ) {
                Mana -= 0.5f;
                mana.fillAmount = Mana / 100;
            }
           

        }
        else
        {
            flames.Stop();
        }
        if (Input.GetKey(KeyCode.Q))
        {
            rocas.Play();
            if (Mana > 0 )
            {
                Mana -= 0.5f;
                mana.fillAmount = Mana / 100;
            }

        }
        else
            {
             
            rocas.Stop();
            }


        if (Mana<=0)
        {
            flames.Stop();
            rocas.Stop();
        }


        if (!Input.GetKey(KeyCode.Q) || !Input.GetKey(KeyCode.E))
        {
            if (Time.time > tiempo)
            {
                if (Mana < 100)
                {
                    Mana += 5f;
                    mana.fillAmount = Mana / 100;
                }


                tiempo = Time.time + RecMana;
            }
        }

        if (Mana > 100)
        {
            Mana = 100;
        }
        

    }

   
}
