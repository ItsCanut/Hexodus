using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Seconds : MonoBehaviour
{
    
    public DateTime tiempo1;
    public GameObject segundos;    

    // Start is called before the first frame update
    void Start()
    {
        tiempo1 = DateTime.Now;
    }

    // Update is called once per frame
    void Update()
    {
        DateTime tiempo2 = DateTime.Now;
        
        TimeSpan total = new TimeSpan(tiempo2.Ticks - tiempo1.Ticks);

        Text text = segundos.GetComponent<Text>();
        int loSegundos = total.Seconds;
        if (loSegundos >= 60)
        {
            loSegundos -= 60;
        }

        if(loSegundos < 10)
        {
            text.text = ":0" + loSegundos.ToString();
        }
        else
        {
            text.text = ":" + loSegundos.ToString();
        }

    }
}
