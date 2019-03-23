using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using Random = UnityEngine.Random;
using System.Collections.Generic;

public class Spawner : MonoBehaviour
{

    //GameObjects  
    public GameObject Enemigo;
    public int cuantosQuieroSpawnear;
    public GameObject nRonda;
    public GameObject nRestantes;
    int ronda;
    


    void Start()
    {
        //Enemigos que spawnean cuando iniciamos el juego.
        for( int i = 0; i < cuantosQuieroSpawnear; i++)
        {
            spawnEnemy();
        }

        cuantosQuieroSpawnear++;
        Text text = nRonda.GetComponent<Text>();
        ronda = Convert.ToInt16(nRonda) + 1;
        text.text = ronda.ToString();
    }

    // Draws a cube to show where the spawn point is... Useful if you don't have a object that show the spawn point
    void OnDrawGizmos()
    {
        // Sets the color to red
        Gizmos.color = Color.red;
        //draws a small cube at the location of the gam object that the script is attached to
        Gizmos.DrawCube(transform.position, new Vector3(0.5f, 0.5f, 0.5f));
    }

    void Update()
    {
        int enemigosRestantes = GameObject.FindGameObjectsWithTag("Robot").Length;
        if ( enemigosRestantes == 1)
        {
            for(int i = 0; i < cuantosQuieroSpawnear; i++)
            {
                spawnEnemy();
            }
            Text text = nRonda.GetComponent<Text>();
            ronda = Convert.ToInt16(nRonda) + 1;
            text.text = ronda.ToString();
            
            cuantosQuieroSpawnear++;
            cuantosQuieroSpawnear++;           
        }

        Text restantes = nRestantes.GetComponent<Text>();

        restantes.text = enemigosRestantes.ToString();

    }
    // spawns an enemy based on the enemy level that you selected
    private void spawnEnemy()
    {
        Instantiate(Enemigo, transform.position, Quaternion.identity);
    }

}

