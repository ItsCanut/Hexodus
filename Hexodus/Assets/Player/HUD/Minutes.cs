using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Minutes : MonoBehaviour
{
    public DateTime tiempo1;
    public GameObject minutos;

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

        Text text = minutos.GetComponent<Text>();
        int losMinutos = total.Minutes;
        
        if (losMinutos.Equals(0))
        {
            text.text = "";
        }
        else
        {
            text.text = losMinutos.ToString();
        }

    }
}
