﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidaIA : MonoBehaviour
{
    public float health = 200f;
    public Transform elPlayer;
    public VidaP elPla;
    public GameObject expl;

    public int losOricos;
    public int losHierricos;

    // Start is called before the first frame update
    private void Start()
    {        
        elPla = GetComponent<VidaP>();
        generarMateriales();
    }

    public void generarMateriales()
    {        
        losOricos = Random.Range(4, 10);
        losHierricos = Random.Range(4, 21);
    }
    public void AplicarDaño(float amount)
    {
        health -= amount;
        if( health <= 0f)
        {
            
            VidaP losMateriales = elPlayer.GetComponent<VidaP>();
            losMateriales.ContarMateriales(losOricos, losHierricos);

           /* GameObject exp = Instantiate(expl, transform.position, Quaternion.identity);*/
            Destroy(this.gameObject, 0.25f);
           // Destroy(exp,1.5f);
        }
    }
}
