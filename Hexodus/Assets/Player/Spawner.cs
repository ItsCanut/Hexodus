using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using Random = UnityEngine.Random;
using System.Collections.Generic;
using System.Threading;

public class Spawner : MonoBehaviour
{

    //declaraciones  
    public GameObject robot;
    public GameObject robotM;
    public int cuantosQuieroSpawnear;
    public GameObject nRonda;
    public GameObject nRestantes;
    int ronda;
    float waveTimer = 5.0f;
    float timeTillWave = 0.0f;
    int contWaves;
    int cuantasWaves;
    public int cuantosRonda;
    bool spawn;
    Text restantes;
    Spawner2 spawner2;

    void Start()
    {
         
        spawner2 = GetComponent<Spawner2>();

        //Enemigos que spawnean cuando iniciamos el juego.
        ronda = 1;
        contWaves = 0;
        spawn = true;
        cuantasWaves = 4;
        restantes = nRestantes.GetComponent<Text>();
        restantes.text = (cuantasWaves * (cuantosQuieroSpawnear + 2)).ToString();
        cuantosRonda = cuantasWaves * cuantosQuieroSpawnear + (spawner2.cuantosQuieroSpawnear * cuantasWaves);
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
        int enemigosRestantes = GameObject.FindGameObjectsWithTag("Enemigo").Length; // devuelve el numero de robots que hay en el mapa
        Text text = nRonda.GetComponent<Text>();
        
        
        if( contWaves >= cuantasWaves && enemigosRestantes.Equals(2) )
        {
            ronda++;
            contWaves = 0;
            cuantasWaves++;
            cuantosRonda = cuantasWaves * cuantosQuieroSpawnear;
            restantes.text = (cuantasWaves * (cuantosQuieroSpawnear + 2)).ToString();
            spawn = true;
        }
        
        if( contWaves < cuantasWaves && spawn )
        {
            spawnTimed(robot);
        }

        text.text = ronda.ToString();

    }

    // con esta función lo que hacemos es clonar el gameobject que queramos y las veces que queramos. 
    private void spawnEnemy(GameObject elEnemigo, int cuantos)
    {
        for (int i = 0; i < cuantos; i++)
        {
            Instantiate(elEnemigo, transform.position, Quaternion.identity);
        }
    }

    private void spawnTimed(GameObject elEnemigo)
    {
        timeTillWave += Time.deltaTime;
        if (timeTillWave >= waveTimer)
        {
            spawnEnemy(robot, cuantosQuieroSpawnear);
            //spawnEnemy(robotM, 1);
            contWaves++;
            timeTillWave = 0.0f;
        }

    }
}



